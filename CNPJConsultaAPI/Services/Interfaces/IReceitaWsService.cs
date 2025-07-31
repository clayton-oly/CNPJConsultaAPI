using CNPJConsultaAPI.DTOs;

namespace CNPJConsultaAPI.Services.Interfaces
{
    public interface IReceitaWsService
    {
        Task<ReceitaWsDTO?> ConsultarCnpjAsync(string cnpj);
    }
}