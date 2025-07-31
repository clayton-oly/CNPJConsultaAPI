using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.DTOs;

namespace CNPJConsultaAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> GetAll();
        Task CreateUsuarioAsync(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Login(UsuarioDTO usuarioDTO);
    }
}
