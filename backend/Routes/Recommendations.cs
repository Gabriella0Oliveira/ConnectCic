using connect_cic_api.Application.Services;
using connect_cic_api.Services.DTO;
using connect_cic_api.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace connect_cic_api.Routes
{
    public record RecommendationRequest(string ProjectPrompt);
    public static class RecommendationRoutes
    {
        public static void MapRecommendationRoutes(this WebApplication app)
        {
            var group = app.MapGroup("/recommendations").WithTags("Recommendations");

            group.MapGet("/test", () => "A API de recomendação está funcionando!");
            
            group.MapPost("/", async (RecommendationRequest request, IRecommendationService recommendationService) =>
            {
                var students = await recommendationService.GetRecommendationsAsync(request.ProjectPrompt);
                if (!students.Any())
                {
                    return Results.NotFound("Nenhum aluno compatível encontrado ou embeddings ainda não gerados.");
                }
                return Results.Ok(students);

            });
            
            group.MapPost("/generate-all-embeddings", async (
                ConnectCICAPIContext context,
                IProfileGeneratorService profileGenerator,
                IOllamaService ollamaService,
                ILogger<Program> logger) =>
            {
                logger.LogInformation("Iniciando geração de embeddings para todos os alunos...");
                var students = await context.Students.ToListAsync();
                int successCount = 0;

                foreach (var student in students)
                {
                    var profileText = await profileGenerator.GenerateStudentProfileTextAsync(student.StudentID);
                    if (string.IsNullOrEmpty(profileText)) continue;

                    var embedding = await ollamaService.GetEmbeddingAsync(profileText);
                    if (embedding != null)
                    {
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine($"DEBUG: Vetor de Embedding Gerado para Aluno ID: {student.StudentID}");
                        Console.WriteLine($"Vetor: [{string.Join(", ", embedding)}]");
                        Console.WriteLine("---------------------------------------------------------\n");

                        student.Embedding = embedding;
                        successCount++;
                        logger.LogInformation($"Embedding gerado com sucesso para o aluno ID: {student.StudentID}");
                    }
                    else
                    {
                        logger.LogWarning($"Falha ao gerar embedding para o aluno ID: {student.StudentID}");
                    }
                    break;
                }

                await context.SaveChangesAsync();
                logger.LogInformation("Geração de embeddings finalizada.");
                return Results.Ok($"{successCount} de {students.Count} perfis de alunos foram gerados/atualizados.");
            });
        }
    }
}