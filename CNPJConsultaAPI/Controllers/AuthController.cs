using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNPJConsultaAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        public AuthController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _usuarioService.Login(usuarioDTO);

            if (usuario == null)
                return Unauthorized("Credenciais inválidas.");

            var token = _tokenService.GerarToken(usuario);
            return Ok(new { token });
        }

    }
}