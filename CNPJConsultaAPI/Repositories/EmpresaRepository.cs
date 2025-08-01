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
            var empresas = await _context.Empresas.ToListAsync();

            return empresas
                .FirstOrDefault(e =>
                    new string(e.Cnpj.Where(char.IsDigit).ToArray()) == cnpj);
        }

        public async Task<List<Empresa>> GetAllEmpresaByIdUsuarioAsync(int id)
        {
            return await _context.Empresas
                .Where(e => e.UsuarioId == id)
                .ToListAsync();
        }
    }
}
