using System.Data;
using connect_cic_api.Domain;
using connect_cic_api.Infra.Persistence;
using connect_cic_api.Services.DTO;

namespace connect_cic_api.Application.Services
{
    public interface IOllamaService
    {
        Task<float[]?> GetEmbeddingAsync(string prompt);
    }
}