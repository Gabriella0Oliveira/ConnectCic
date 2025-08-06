namespace connect_cic_api.Domain;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    public int StudentID { get; set; }
    public string? Name { get; set; }
    public string? Matricula { get; set; }
    public string? Email { get; set; }
    public string? Course { get; set; }
    public string? Description { get; set; }
    public float CRAA { get; set; }
    public string? Status { get; set; }
    public virtual ICollection<Vacancy>? Vacancies { get; set; }
    public virtual ICollection<StudentArea> StudentAreas { get; set; } = new List<StudentArea>();
    public virtual ICollection<StudentDiscipline> StudentDisciplines { get; set; } = new List<StudentDiscipline>();
    public virtual int? UserID { get; set; }
    public virtual User? User { get; set; }
    public byte[]? ProfileEmbedding { get; set; }

    [NotMapped]
    public float[]? Embedding
    {
        get => ProfileEmbedding == null ? null : ToFloatArray(ProfileEmbedding);
        set => ProfileEmbedding = value == null ? null : ToByteArray(value);
    }
    
    private static byte[] ToByteArray(float[] floatArray)
    {
        var byteArray = new byte[floatArray.Length * 4];
        Buffer.BlockCopy(floatArray, 0, byteArray, 0, byteArray.Length);
        return byteArray;
    }

    private static float[] ToFloatArray(byte[] byteArray)
    {
        var floatArray = new float[byteArray.Length / 4];
        Buffer.BlockCopy(byteArray, 0, floatArray, 0, byteArray.Length);
        return floatArray;
    }
}
