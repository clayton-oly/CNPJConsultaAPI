using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Services;
using CNPJConsultaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO usuarioDTO)
        {
            await _usuarioService.CreateUsuarioAsync(usuarioDTO);
            return Ok("Usuário criado com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = await _usuarioService.Login(usuarioDTO);

            if (usuario == null)
                return Unauthorized("Email ou senha inválidos.");
            else
            {
                return Ok();
            }
        }
    }
}
