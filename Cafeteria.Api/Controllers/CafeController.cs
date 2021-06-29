using Cafeteria.Api.Business;
using Cafeteria.Api.Domain.Models;
using Cafeteria.Api.Domain.Models.Request;
using Cafeteria.Api.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Response = Cafeteria.Api.Domain.Models.Response.Response;

namespace Cafeteria.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CafeController : ControllerBase
    {
        private readonly CafeBL _cafeBL;

        public CafeController(CafeBL cafeBL)
        {
            _cafeBL = cafeBL;
        }

        /// <summary>
        /// Cadastra Cafés
        /// </summary>
        /// <param name="cafeReq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CafeRequest cafeReq) //IActionResult - (retorna qualquer tipo de resultado)
                                                                    //FROMBODY - recebe um objeto do tipo alunoRequest - um corpo de dados
        {
            var idCafe = _cafeBL.InsertCafe(cafeReq); //chamar o metodo que fara a inserção no banco de dados, no caso a regra de negocio cafeBL

            //return CreatedAtAction(nameof(GetById), new { id= idCafe}, cafeReq);
            return Ok(new Response { Message = "Café cadastrado com sucesso." });
        }

        /// <summary>
        /// Atualiza Cafés
        /// </summary>
        /// <param name="cafeUpdateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] CafeUpdateRequest cafeUpdateRequest)
        {
            var linhasAfetadas = _cafeBL.Update(cafeUpdateRequest);

            if (cafeUpdateRequest.IdCafe != 0)
            {
                return Ok(new Response { Message = "Café atualizado com sucesso." }); //Message retorna da classe response
            }

            else
            {
                return BadRequest(new { message = "Erro ao atualizar o cadastro de Café, contate o administrador." });//message retorna direto do sistema
            }
        }
        /// <summary>
        /// Buscar Café po ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(CafeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var cafeResponse = _cafeBL.GetCafeById(id);

            if (cafeResponse != null)
            {
                return Ok(cafeResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum Registro foi encontrado." });
            }
        }

        /// <summary>
        /// Buscar todos os Cafés
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(IEnumerable<CafeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var loginResponse = _cafeBL.GetAllCafe();

            if (loginResponse.Any())
            {
                return Ok(loginResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Erro, contate o administrador" });//pode fazer retorno pela response ou retorno pelo sistema sem colocar o Response
            }
        }

        /// <summary>
        /// Apagar Cafés
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var linhasAfetadas = _cafeBL.Delete(id);

            if (linhasAfetadas == 1) //ou if(login response !=0)
            {
                return Ok(new Response { Message = "Caféexcluido com sucesso" });
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum Café foi encontrado." }); // ou return BadRequest(new Response{ Message = "Nenhum aluno foi encontrado." });
            }
        }
    }
}
