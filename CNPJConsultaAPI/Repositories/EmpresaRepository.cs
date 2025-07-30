using CNPJConsultaAPI.Data;
using CNPJConsultaAPI.Interfaces;
using CNPJConsultaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly CNPJConsultaAPIDbContext _context;
        public EmpresaRepository(CNPJConsultaAPIDbContext cnpjConsultaAPIDbContext)
        {
            _context = cnpjConsultaAPIDbContext;
        }

        public async Task AddEmpresaAsync(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Empresa>> GetAllAsync()
        {
            return await _context.Empresas.Include(u => u.Usuario).ToListAsync();
        }
    }
}
