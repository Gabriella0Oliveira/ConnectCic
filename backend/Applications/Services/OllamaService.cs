using System.Data;
using connect_cic_api.Domain;
using connect_cic_api.Infra.Persistence;
using connect_cic_api.Services.DTO;

namespace connect_cic_api.Application.Services
{
    // DTOs para a resposta e requisição do Ollama
    public record OllamaEmbeddingRequest(string model, string prompt);
    public record OllamaEmbeddingResponse(float[] embedding);

    public class OllamaService : IOllamaService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _modelName;

        public OllamaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _modelName = _configuration["Ollama:Model"] ?? "llama3"; 
        }

        public async Task<float[]?> GetEmbeddingAsync(string prompt)
        {
            var requestPayload = new OllamaEmbeddingRequest(_modelName, prompt);

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/embeddings", requestPayload);
                response.EnsureSuccessStatusCode();
                var embeddingResponse = await response.Content.ReadFromJsonAsync<OllamaEmbeddingResponse>();
                return embeddingResponse?.embedding;
            }
            catch (HttpRequestException e)
            {
                
                Console.WriteLine($"Erro ao conectar com o Ollama: {e.Message}");
                return null;
            }
        }
    }
}