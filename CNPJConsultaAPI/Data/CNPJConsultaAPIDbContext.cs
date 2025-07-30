using CNPJConsultaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Data
{
    public class CNPJConsultaAPIDbContext : DbContext
    {
        public CNPJConsultaAPIDbContext(DbContextOptions<CNPJConsultaAPIDbContext> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}
