using AutoMapper;
using Cafeteria.Api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Business
{
    public class DocesBL
    {
        private readonly IMapper _mapper;
        private readonly DocesRepository _docesRepository;

        public DocesBL(IMapper mapper, DocesRepository docesRepository)
        {
            _mapper = mapper;
            _docesRepository = docesRepository;
        }

    }
}
