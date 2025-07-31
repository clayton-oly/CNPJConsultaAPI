using CNPJConsultaAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {

        Task AddUsuarioAsync(Usuario usuario);
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetUsuarioByEmailAsync(string email);
        Task<Usuario> Login(Usuario usuario);
    }
}
