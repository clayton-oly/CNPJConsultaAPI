using AutoMapper;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Models;
using CNPJConsultaAPI.Repositories;
using CNPJConsultaAPI.Repositories.Interfaces;
using CNPJConsultaAPI.Services.Interfaces;

namespace CNPJConsultaAPI.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task CreateEmpresaAsync(EmpresaDTO empresaDTO)
        {
            var empresa = _mapper.Map<Empresa>(empresaDTO);
            await _empresaRepository.AddEmpresaAsync(empresa);
        }

        public async Task<List<EmpresaDTO>> ListarEmpresas()
        {
           var empresas = await _empresaRepository.GetAllAsync();
           return _mapper.Map<List<EmpresaDTO>>(empresas);
        }
    }
}
