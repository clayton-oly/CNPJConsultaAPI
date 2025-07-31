using CNPJConsultaAPI.DTO;

namespace CNPJConsultaAPI.Services.Interfaces
{
    public interface IEmpresaService
    {
        Task CreateEmpresaAsync(string cnpj, int id);
        Task<List<EmpresaDTO>> GetAllEmpresaByIdUsuarioAsync(int id);
    }
}
