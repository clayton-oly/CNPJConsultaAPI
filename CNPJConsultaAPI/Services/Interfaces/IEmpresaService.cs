using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.Models;

namespace CNPJConsultaAPI.Services.Interfaces
{
    public interface IEmpresaService
    {
        Task CreateEmpresaAsync(EmpresaDTO empresaDTO);
        Task<List<EmpresaDTO>> ListarEmpresas();
    }
}
