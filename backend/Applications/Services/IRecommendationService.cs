using System.Data;
using connect_cic_api.Infra.Persistence;
using connect_cic_api.Services.DTO;
using connect_cic_api.Domain;

namespace connect_cic_api.Application.Services
{
    public interface IRecommendationService
    {
        Task<IEnumerable<Student>> GetRecommendationsAsync(string projectPrompt);
    }
}