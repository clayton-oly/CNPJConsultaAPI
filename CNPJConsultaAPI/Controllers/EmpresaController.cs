using CNPJConsultaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CNPJConsultaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery][Required] string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return BadRequest(new { message = "O CNPJ é obrigatório." });

            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdString, out int userId))
                return Unauthorized(new { message = "Usuário inválido ou não autenticado." });

            try
            {
                await _empresaService.CreateEmpresaAsync(cnpj, userId);
                return Ok(new { message = "Empresa cadastrada com sucesso." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno no servidor." });
            }
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var id))
            {
                return Unauthorized("Usuário inválido ou token expirado.");
            }

            var empresaDTOs = await _empresaService.GetAllEmpresaByIdUsuarioAsync(id);

            return Ok(empresaDTOs);
        }

    }
}
