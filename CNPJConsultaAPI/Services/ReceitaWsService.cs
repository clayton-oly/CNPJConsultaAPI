using CNPJConsultaAPI.DTOs;
using CNPJConsultaAPI.Services.Interfaces;

namespace CNPJConsultaAPI.Services
{
    public class ReceitaWsService : IReceitaWsService
    {
        private readonly HttpClient _httpClient;

        public ReceitaWsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReceitaWsDTO?> ConsultarCnpjAsync(string cnpj)
        {
            try
            {
                var url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";
                return await _httpClient.GetFromJsonAsync<ReceitaWsDTO>(url);
            }
            catch
            {
                return null;
            }
        }
    }
}