using AutoMapper;
using Cafeteria.Api.Data.Entities;
using Cafeteria.Api.Data.Repositories;
using Cafeteria.Api.Domain.Models;
using Cafeteria.Api.Domain.Models.Request;
using Signa.Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafeteria.Api.Business
{
    public class CafeBL
    {
        private readonly IMapper _mapper; //automapper para fazer mapeamento entre as classes
        private readonly CafeRepository _cafeRepository; //

        public CafeBL(IMapper mapper, CafeRepository cafeRepository)
        {
            _mapper = mapper;
            _cafeRepository = cafeRepository;
        }
        public int InsertCafe(CafeRequest cafeRequest) //
        {
            VerificaSeCafeJaExiste(cafeRequest.Nome); //para não inserir um café, caso já exista

            var alunoEntity = _mapper.Map<CafeEntity>(cafeRequest); //variável que terá retorno do banco e faz mapeamento com caféEntity (variável que executa um metodo)
            var idAluno = _cafeRepository.Insert(alunoEntity); // var que retorna o id do café

            return idAluno;
        }

        public int Update(CafeUpdateRequest cafeUpdateRequest)
        {
            var aluno = _cafeRepository.GetCafeById(cafeUpdateRequest.IdCafe); //para saber qual é o Id do aluno

            if (aluno == null) //if (string.IsNullOrWhiteSpace(nome)
            {
                throw new SignaRegraNegocioException("Nenhum Café foi encontrado");
            }

            var cafeEntity = _mapper.Map<CafeEntity>(cafeUpdateRequest);
            var linhasafetadas = _cafeRepository.Update(cafeEntity);

            return linhasafetadas;
        }
        public CafeResponse GetCafeById(int id)
        {
            var loginEntity = _cafeRepository.GetCafeById(id);
            var loginResponse = _mapper.Map<CafeResponse>(loginEntity);

            return loginResponse;
        }
        public IEnumerable<CafeResponse> GetAllCafe()
        {
            var cafeEntities = _cafeRepository.GetAllCafe();
            var cafeResponse = cafeEntities.Select(x => _mapper.Map<CafeResponse>(x));

            return cafeResponse;
        }
        public int Delete(int id)
        {
            var loginEntity = _cafeRepository.GetCafeById(id);

            if (loginEntity != null) //if(idCafe != null) 
            {
                var linhasAfetadas = _cafeRepository.Delete(id); //retrun _cafeRepository.Delete (id);

                return linhasAfetadas;
            }
            else
            {
                throw new SignaRegraNegocioException("Erro ao excluir o Café, contate o administrador");
            }
        }
        private void VerificaSeCafeJaExiste(string nome)
        {
            var id = _cafeRepository.GetIdByNome(nome);

            if (id != 0)
            {
                //return Ok(new Response {Message = "Já existe Aluno com esse nome"}
                throw new SignaRegraNegocioException("Já existe um usuário cadastrado com esse nome"); //ou exception no lugar de Signa...
            }
        }
    }
}
