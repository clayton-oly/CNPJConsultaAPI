using AutoMapper;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Models;
using CNPJConsultaAPI.Repositories.Interfaces;
using CNPJConsultaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CNPJConsultaAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IPasswordHasher<Usuario> passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<List<UsuarioDTO>> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAll();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public async Task CreateUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioExistente = await _usuarioRepository.GetUsuarioByEmailAsync(usuario.Email);

            if (usuarioExistente == null)
            {
                usuario.Senha = _passwordHasher.HashPassword(usuario, usuarioDTO.Senha);
                await _usuarioRepository.AddUsuarioAsync(usuario);
            }
            else
            {
                throw new Exception("Usuário já existe com esse e-mail.");
            }
        }

        public async Task<UsuarioDTO?> Login(UsuarioDTO usuarioDTO)
        {
            var usuarioNoBanco = await _usuarioRepository.GetUsuarioByEmailAsync(usuarioDTO.Email);

            if (usuarioNoBanco == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(usuarioNoBanco, usuarioNoBanco.Senha, usuarioDTO.Senha);

            if (result != PasswordVerificationResult.Success)
                return null;

            return _mapper.Map<UsuarioDTO>(usuarioNoBanco);
        }

    }
}
