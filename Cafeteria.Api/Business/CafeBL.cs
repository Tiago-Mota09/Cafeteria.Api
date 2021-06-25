using AutoMapper;
using Cafeteria.Api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Business
{
    public class CafeBL
    {
        private readonly IMapper _mapper; //automapper para fazer mapeamento entre as classes
        private readonly CafeRepository _cafeRepository; //
    }
}
