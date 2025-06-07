// Domain/StudentDiscipline.cs
namespace connect_cic_api.Domain;

public class StudentDiscipline
{
    public int     StudentId    { get; set; }
    public int     DisciplineId { get; set; }
    public decimal Grade        { get; set; }    // antes Nota
    public string? Experience   { get; set; }    // antes Experiencia
    public DateTime UpdatedAt   { get; set; }

    public virtual Student    Student    { get; set; } = null!;
    public virtual Discipline Discipline { get; set; } = null!;
}
