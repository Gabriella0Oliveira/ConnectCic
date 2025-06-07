// Domain/Area.cs
namespace connect_cic_api.Domain;

public class Area
{
    public int    AreaId { get; set; }
    public string Name   { get; set; } = null!;

    public virtual ICollection<StudentArea> StudentAreas { get; set; } = new List<StudentArea>();
}
