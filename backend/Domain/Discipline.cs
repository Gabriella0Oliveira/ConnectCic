// Domain/Discipline.cs
namespace connect_cic_api.Domain;

public class Discipline
{
    public int DisciplineId { get; set; }
    public string Name         { get; set; } = null!;
    public string Code         { get; set; } = null!;
    public int Semester     { get; set; }
    public string Syllabus     { get; set; } = null!;   // antes Ementa
    public string Objectives   { get; set; } = null!;   // antes Objetivos
    public string Content      { get; set; } = null!;   // antes Conteudo

    public virtual ICollection<StudentDiscipline> StudentDisciplines { get; set; } = new List<StudentDiscipline>();
}
