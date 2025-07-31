using CNPJConsultaAPI.DTO;
using CNPJConsultaAPI.DTOs;

namespace CNPJConsultaAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(UsuarioDTO usuarioDTO);
    }
}
