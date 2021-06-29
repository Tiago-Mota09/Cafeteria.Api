using AutoMapper;
using Cafeteria.Api.Data.Entities;
using Cafeteria.Api.Domain.Models;
using Cafeteria.Api.Domain.Models.Request;

namespace Cafeteria.Api.Profiles
{
    public class CafeProfile : Profile
    {
        public CafeProfile()
        {
            CreateMap<CafeRequest, CafeEntity>().ReverseMap(); //Mapeamento entre duas classes, pois podem ter Parametros da entity que não tem na request
            CreateMap<CafeEntity, CafeResponse>().ReverseMap();
            CreateMap<CafeUpdateRequest, CafeEntity>().ReverseMap();
        }
    }
}

