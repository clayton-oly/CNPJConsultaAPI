using CNPJConsultaAPI.Models;

namespace CNPJConsultaAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AddUsuarioAsync(Usuario usuario);
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> GetUsuarioByEmailAsync(string email);
    }
}
