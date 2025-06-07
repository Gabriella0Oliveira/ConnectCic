// Domain/StudentArea.cs
namespace connect_cic_api.Domain;

public class StudentArea
{
    public int  StudentId { get; set; }
    public int  AreaId    { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual Student Student { get; set; } = null!;
    public virtual Area    Area    { get; set; } = null!;
}
