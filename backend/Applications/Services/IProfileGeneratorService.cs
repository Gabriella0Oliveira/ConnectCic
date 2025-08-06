
namespace connect_cic_api.Application.Services
{
    public interface IProfileGeneratorService
    {
        Task<string> GenerateStudentProfileTextAsync(int studentId);
    }
}