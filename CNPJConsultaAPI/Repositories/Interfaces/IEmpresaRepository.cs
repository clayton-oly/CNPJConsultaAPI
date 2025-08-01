using CNPJConsultaAPI.Models;

namespace CNPJConsultaAPI.Repositories.Interfaces
{
    public interface IEmpresaRepository
    {
        Task AddEmpresaAsync(Empresa empresa);
        Task<List<Empresa>> GetAllEmpresaByIdUsuarioAsync(int id);
        Task<Empresa> GetByCnpjAsync(string cnpj);
    }
}
