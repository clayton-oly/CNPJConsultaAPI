using AutoMapper;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Models;
using CNPJConsultaAPI.Repositories.Interfaces;
using CNPJConsultaAPI.Services.Interfaces;
using CNPJConsultaAPI.Utils;

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

        public async Task CreateEmpresaAsync(string cnpj, int usuarioId)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("CNPJ não pode ser vazio.");

            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                throw new ArgumentException("CNPJ deve conter 14 dígitos numéricos.");

            if (!CnpjUtils.IsCnpjValido(cnpj))
                throw new ArgumentException("CNPJ inválido.");

            var empresaExistente = await _empresaRepository.GetByCnpjAsync(cnpj);
            if (empresaExistente != null)
                throw new InvalidOperationException("Empresa já cadastrada.");

            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(usuarioId);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            var receitaWsDTO = await _receitaWsService.ConsultarCnpjAsync(cnpj);
            if (receitaWsDTO == null || receitaWsDTO.Status != "OK")
                throw new Exception("Não foi possível consultar os dados da ReceitaWS para o CNPJ informado.");

            var empresa = _mapper.Map<Empresa>(receitaWsDTO);

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
