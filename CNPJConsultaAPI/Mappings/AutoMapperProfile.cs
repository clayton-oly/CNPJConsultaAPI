using AutoMapper;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.DTOs;
using CNPJConsultaAPI.Models;

namespace CNPJConsultaAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();

            CreateMap<ReceitaWsDTO, Empresa>()
             .ForMember(dest => dest.NomeEmpresarial, opt => opt.MapFrom(src => src.Nome))
             .ForMember(dest => dest.NomeFantasia, opt => opt.MapFrom(src => src.Fantasia))
             .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
             .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => src.Situacao))
             .ForMember(dest => dest.Abertura, opt => opt.MapFrom(src => src.Abertura))
             .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
             .ForMember(dest => dest.NaturezaJuridica, opt => opt.MapFrom(src => src.NaturezaJuridica))
             .ForMember(dest => dest.AtividadePrincipal, opt =>
                 opt.MapFrom(src => (src.AtividadePrincipal != null && src.AtividadePrincipal.Count > 0)
                     ? src.AtividadePrincipal[0].Text : string.Empty))
             .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
             .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
             .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento))
             .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
             .ForMember(dest => dest.Municipio, opt => opt.MapFrom(src => src.Municipio))
             .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf))
             .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep));

        }
    }
}
