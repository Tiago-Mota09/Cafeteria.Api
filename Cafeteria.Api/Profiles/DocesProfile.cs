using AutoMapper;
using Cafeteria.Api.Data.Entities;
using Cafeteria.Api.Domain;
using Cafeteria.Api.Domain.Models.Request;
using Cafeteria.Api.Domain.Models.Response;

namespace Cafeteria.Api.Profiles
{
    public class DocesProfile : Profile
    {
        public DocesProfile()
        {
            CreateMap<DocesRequest, DocesEntity>().ReverseMap();
            CreateMap<DocesUpdateRequest, DocesEntity>().ReverseMap();
            CreateMap<DocesEntity, DocesResponse>().ReverseMap();
        }
    }
}
