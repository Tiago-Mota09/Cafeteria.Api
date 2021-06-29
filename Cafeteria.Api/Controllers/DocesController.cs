using Cafeteria.Api.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Controllers
{
    [ApiController]
    [Route("[Controler]")]

    public class DocesController : Controller
    {
        private readonly DocesBL _docesBL;
        public DocesController(DocesBL docesBL)
        {
            _docesBL = docesBL;
        }

    }
}
