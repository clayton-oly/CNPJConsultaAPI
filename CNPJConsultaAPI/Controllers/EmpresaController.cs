using CNPJConsultaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create(string cnpj)
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            await _empresaService.CreateEmpresaAsync(cnpj, id);
            return Ok("Empresa cadastrada com sucesso");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var empresaDTOs = await _empresaService.GetAllEmpresaByIdUsuarioAsync(id);
            return Ok(empresaDTOs);
        }
    }
}
