using connect_cic_api.Domain;
using connect_cic_api.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace connect_cic_api.Application.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ConnectCICAPIContext _context;
        private readonly IOllamaService _ollamaService;

        public RecommendationService(ConnectCICAPIContext context, IOllamaService ollamaService)
        {
            _context = context;
            _ollamaService = ollamaService;
        }

        public async Task<IEnumerable<Student>> GetRecommendationsAsync(string projectPrompt)
        {
            if (string.IsNullOrWhiteSpace(projectPrompt))
            {
                return Enumerable.Empty<Student>();
            }

            //Gera o embedding para o prompt do projeto em tempo real
            var promptEmbedding = await _ollamaService.GetEmbeddingAsync(projectPrompt);
            if (promptEmbedding == null)
            {
                // Falha ao comunicar com o Ollama ou gerar o embedding
                return Enumerable.Empty<Student>();
            }

            //Buscando todos os alunos com um embedding no banco
            var studentsWithEmbeddings = await _context.Students
                .Where(s => s.ProfileEmbedding != null)
                .ToListAsync();

            if (!studentsWithEmbeddings.Any())
            {
                return Enumerable.Empty<Student>();
            }

            // Calcula a similaridade para cada aluno e ordena
            var rankedStudents = studentsWithEmbeddings
                .Select(student => new
                {
                    Student = student,
                    
                    Similarity = CalculateCosineSimilarity(promptEmbedding, student.Embedding!)
                })
                .OrderByDescending(x => x.Similarity)
                .Select(x => x.Student);

            //Retorna os 5 melhores resultados
            return rankedStudents.Take(5);
        }

        private double CalculateCosineSimilarity(float[] vecA, float[] vecB)
        {
            if (vecA.Length != vecB.Length)
                throw new ArgumentException("Os vetores precisam ter a mesma dimensão.");

            double dotProduct = 0.0;
            double magA = 0.0;
            double magB = 0.0;

            for (int i = 0; i < vecA.Length; i++)
            {
                dotProduct += vecA[i] * vecB[i];
                magA += Math.Pow(vecA[i], 2);
                magB += Math.Pow(vecB[i], 2);
            }

            magA = Math.Sqrt(magA);
            magB = Math.Sqrt(magB);

            if (magA == 0 || magB == 0) return 0;

            return dotProduct / (magA * magB);
        }
    }
}