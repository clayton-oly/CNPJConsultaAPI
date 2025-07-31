using System.Security.Claims;
using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Services;
using CNPJConsultaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CNPJConsultaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;


        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpresaDTO empresaDTO)
        {
            await _empresaService.CreateEmpresaAsync(empresaDTO);
            return Ok("Empresa cadastrada com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresaDTOs = await _empresaService.ListarEmpresas();
            return Ok(empresaDTOs);
        }

        //[HttpGet]
        //public IActionResult ListarEmpresas()
        //{
        //    var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        //    if (claim == null)
        //        return Unauthorized("Usuário não autenticado.");

        //    var usuarioId = int.Parse(claim.Value);

        //    var empresas = _context.Empresas
        //        .Where(e => e.UsuarioId == usuarioId)
        //        .ToList();

        //    return Ok(empresas);
        //}
    }
}
