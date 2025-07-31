using CNPJConsultaAPI.Data;
using CNPJConsultaAPI.Models;
using CNPJConsultaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CNPJConsultaAPIDbContext _context;

        public UsuarioRepository(CNPJConsultaAPIDbContext cnpjConsultaAPIDbContext)
        {
            _context = cnpjConsultaAPIDbContext;
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
           await _context.Usuarios.AddAsync(usuario);
           await _context.SaveChangesAsync(); 
        }

        public async Task<List<Usuario>> GetAll()
        {
            return  await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return  await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }
    }
}
