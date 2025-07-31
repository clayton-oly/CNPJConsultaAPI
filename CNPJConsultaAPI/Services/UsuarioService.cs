using AutoMapper;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Models;
using CNPJConsultaAPI.Repositories.Interfaces;
using CNPJConsultaAPI.Services.Interfaces;

namespace CNPJConsultaAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<List<UsuarioDTO>> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAll();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public async Task CreateUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            if (_usuarioRepository.GetUsuarioByEmailAsync(usuario.Email) == null)
            {
                await _usuarioRepository.AddUsuarioAsync(usuario);
            }
        
        }

        public async Task<UsuarioDTO> Login(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            usuario = await _usuarioRepository.Login(usuario);
            usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }
    }

}
