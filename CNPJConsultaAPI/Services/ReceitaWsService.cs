using CNPJConsultaAPI.DTOs;
using CNPJConsultaAPI.Services.Interfaces;

namespace CNPJConsultaAPI.Services
{
    public class ReceitaWsService : IReceitaWsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ReceitaWsService> _logger;

        public ReceitaWsService(HttpClient httpClient, ILogger<ReceitaWsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ReceitaWsDTO?> ConsultarCnpjAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                _logger.LogWarning("CNPJ inválido para consulta.");
                return null;
            }

            try
            {
                var url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Falha ao consultar CNPJ {Cnpj}. Status code: {StatusCode}", cnpj, response.StatusCode);
                    return null;
                }

                var receita = await response.Content.ReadFromJsonAsync<ReceitaWsDTO>();
                return receita;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erro de rede ao consultar CNPJ {Cnpj}", cnpj);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao consultar CNPJ {Cnpj}", cnpj);
                return null;
            }
        }
    }
}