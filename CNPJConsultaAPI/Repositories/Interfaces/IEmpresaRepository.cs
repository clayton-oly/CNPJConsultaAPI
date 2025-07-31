using CNPJConsultaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Repositories.Interfaces
{
    public interface IEmpresaRepository
    {
        Task AddEmpresaAsync(Empresa empresa);
        Task<List<Empresa>> GetAllAsync();
    }
}
