using CNPJConsultaAPI.Data;
using CNPJConsultaAPI.Models;
using CNPJConsultaAPI.Repositories.Interfaces;
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

        public async Task<Empresa> GetByCnpjAsync(string cnpj)
        {
            return await _context.Empresas.FirstOrDefaultAsync(e => e.Cnpj == cnpj);
        }

        public async Task<List<Empresa>> GetAllEmpresaByIdUsuarioAsync(int id)
        {
            return await _context.Empresas
                .Where(e => e.UsuarioId == id)
                .ToListAsync();
        }

        public async Task UpdateEmpresaAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
        }
    }
}
