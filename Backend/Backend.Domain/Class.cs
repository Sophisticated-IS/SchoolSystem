using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class Class 
{
    public int Id { get; init; }
    /// <summary>
    /// Буква класса 
    /// </summary>
    public char Letter { get; set; }
    public Parallel Parallel { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
}