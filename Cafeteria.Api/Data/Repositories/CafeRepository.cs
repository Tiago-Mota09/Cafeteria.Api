using Cafeteria.Api.Data.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Cafeteria.Api.Data.Repositories
{
    public class CafeRepository : RepositoryBase
    {
        public CafeRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(CafeEntity cafe) //
        {
            using var db = Connection; //Para conectar ao banco

            //metodo de insert a seguir:  //@ para poder pular linhas e reconhecer identação do banco //status não precisa, pois já vem com 1 como padrão
            //1ª parte INSERT quais colunas será inserido valores
            //2ª parte VALUES referenciando com a classe entity(Escrito igual no entity)
            var query = @"INSERT INTO cafe           
                            (nome,
                             tipo,
                             ingredientes,
                             tamanho,
                             preco)
                     values( @Nome, 
                             @Tipo,
                             @Ingredientes,
                             @Tamanho,
                             @Preco)
                             RETURNING idCafe;";  //

            return db.ExecuteScalar<int>(query, new //ExecuteScalar retornar vários tipos de dados //new = instanciando algo novo
                                                    //retorno para executar a query
            {
                cafe.Nome,
                cafe.Tipo,
                cafe.Ingredientes,
                cafe.Tamanho,
                cafe.Preco
            });
        }
        public int Update(CafeEntity login)
        {
            using var db = Connection;

            var query = @"UPDATE cafe
                            SET nome  = @Nome,
                                email = @Tipo
                                email = @Ingredientes,
                                email = @Tamanho,
                                senha = @Preco
                            WHERE idCafe = @IdCafe;";

            return db.Execute(query, new
            {
                login.Nome,
                login.Tipo,
                login.Ingredientes,
                login.Tamanho,
                login.Preco
            });
        }
        public CafeEntity GetLogin(int idCafe)
        {
            using var db = Connection;

            var query = @"Select idCafe
                          From cafe
                                WHERE idCafe = @IdCafe;";

            return db.QueryFirstOrDefault<CafeEntity>(query, new { idCafe });
        }
        public string GetNomeLoginById(int idCafe)
        {
            using var db = Connection;

            var query = @"SELECT nome
                            FROM Cafe 
                        WHERE idCafe = @IdCafe;";

            return db.ExecuteScalar<string>(query, new { idCafe });
        }
        public CafeEntity GetCafeById(int id)
        {
            using var db = Connection;

            var query = @"SELECT idCafe,
                              nome,
                              tipo,
                              ingredientes,
                              tamanho,
                              preco
                            FROM cafe
                          WHERE idCafe = @IdCafe;";

            return db.QueryFirstOrDefault<CafeEntity>(query, new { id });//pra retornar a primeira entidade que achar ou null
        }
        public int GetIdByNome(string nome)
        {
            using var db = Connection;

            var query = @"select idCafe 
	                        from cafe
                        WHERE nome = @Nome
	                        AND idCafe != 0";

            return db.ExecuteScalar<int>(query, new { nome });
        }

        public IEnumerable<CafeEntity> GetAllCafe()
        {
            using var db = Connection;

            var query = @"SELECT
                             idCafe,
                             nome,
                             tipo,
                             ingredientes,
                             tamanho,
                             preco
                        FROM Login
                            WHERE idCafe != 0; ";

            return db.Query<CafeEntity>(query);
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE Cafe      
                        SET idCafe = null
                      WHERE idCafe = @IdCafe";

            return db.Execute(query, new { id });
        }
    }
}
