using Cafeteria.Api.Business;
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
    }
}
