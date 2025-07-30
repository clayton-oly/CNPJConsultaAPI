using AutoMapper;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Models;

namespace CNPJConsultaAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
        }
    }
}
