using AutoMapper;
using WebApiComidasSeg.DTOs;
using WebApiComidasSeg.Entidades;

namespace WebApiComidasSeg.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ComidaDTO, Comida>();
            CreateMap<Comida, GetComidaDTO>();
        }
    }
}
