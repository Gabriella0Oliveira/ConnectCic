using connect_cic_api.Domain;
using connect_cic_api.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace connect_cic_api.Application.Services
{
    public class ProfileGeneratorService : IProfileGeneratorService
    {
        private readonly ConnectCICAPIContext _context;

        public ProfileGeneratorService(ConnectCICAPIContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateStudentProfileTextAsync(int studentId)
        {
            var student = await _context.Students
                .AsNoTracking() 
                .Include(s => s.StudentAreas)
                    .ThenInclude(sa => sa.Area)
                .Include(s => s.StudentDisciplines)
                    .ThenInclude(sd => sd.Discipline)
                .FirstOrDefaultAsync(s => s.StudentID == studentId);

            if (student == null) return string.Empty;

            var profileBuilder = new StringBuilder();
            profileBuilder.Append($"{student.Name}, estudante de {student.Course} com CRAA {student.CRAA}. ");
            if (!string.IsNullOrWhiteSpace(student.Description))
            {
                profileBuilder.Append($"Descrição pessoal: {student.Description}. ");
            }

            var areas = student.StudentAreas.Select(sa => sa.Area.Name).ToList();
            if (areas.Any())
            {
                profileBuilder.Append($"Tem interesse em: {string.Join(", ", areas)}. ");
            }

            var experiences = student.StudentDisciplines.ToList();
            if (experiences.Any())
            {
                profileBuilder.Append("Cursou as disciplinas de: ");
                foreach (var exp in experiences)
                {
                    profileBuilder.Append($"{exp.Discipline.Name} (nota {exp.Grade})");
                    if (!string.IsNullOrWhiteSpace(exp.Experience))
                    {
                         profileBuilder.Append($", com a seguinte experiência registrada: '{exp.Experience}'. ");
                    } else {
                         profileBuilder.Append(". ");
                    }
                }
            }

            Console.WriteLine("=========================================================");
            Console.WriteLine($"DEBUG: Perfil Textual Gerado para Aluno ID: {student.StudentID}");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(profileBuilder.ToString());
            Console.WriteLine("=========================================================\n");
        
            return profileBuilder.ToString();
        }
    }
}