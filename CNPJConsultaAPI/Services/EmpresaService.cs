using AutoMapper;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Models;
using CNPJConsultaAPI.Repositories.Interfaces;
using CNPJConsultaAPI.Services.Interfaces;

namespace CNPJConsultaAPI.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IReceitaWsService _receitaWsService;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper, IReceitaWsService receitaWsService, IUsuarioRepository usuarioRepository)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _receitaWsService = receitaWsService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateEmpresaAsync(string cnpj, int id)
        {
            var empresa = await _empresaRepository.GetByCnpjAsync(cnpj);
            if (empresa != null)
                throw new Exception("Empresa já cadastrada.");

            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            var receitaWsDTO = await _receitaWsService.ConsultarCnpjAsync(cnpj);

            empresa = _mapper.Map<Empresa>(receitaWsDTO);

            empresa.UsuarioId = usuario.IdUsuario;

            await _empresaRepository.AddEmpresaAsync(empresa);
        }


        public async Task<List<EmpresaDTO>> GetAllEmpresaByIdUsuarioAsync(int id)
        {
            var empresas = await _empresaRepository.GetAllEmpresaByIdUsuarioAsync(id);
            return _mapper.Map<List<EmpresaDTO>>(empresas);
        }
    }
}
