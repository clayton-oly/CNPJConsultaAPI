using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.DTOs;
using CNPJConsultaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }
    }
}
