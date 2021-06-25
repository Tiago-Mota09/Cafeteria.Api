using Cafeteria.Api.Data.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
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
            var query = @"INSERT INTO CAFE           
                            (idCafe
                             nome,
                             tipo,
                             ingredientes,
                             tamanho,
                             preco)
                     values( @Nome, 
                             @tipo,
                             @ingredientes,
                             @tamanho)
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
    }
}
