using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Interfaces;
using CNPJConsultaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            await _usuarioRepository.AddUsuarioAsync(usuario);

            return (Ok());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            usuario = await _usuarioRepository.Login(usuarioDTO);

            if (usuario == null)
                return Unauthorized("Email ou senha inválidos.");

            // Aqui você pode gerar um token JWT, por exemplo (não incluso neste exemplo)
            return Ok(usuario);
        }
        
        public async Task<Usuario>
    }
}
