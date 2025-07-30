using CNPJConsultaAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CNPJConsultaAPI.Interfaces
{
    public interface IUsuarioRepository
    {

        Task AddUsuarioAsync(Usuario usuario);
        Task<List<Usuario>> GetAll();
        [HttpPost("login")]
        Task<Usuario> Login(Usuario usuario);
    }
}
