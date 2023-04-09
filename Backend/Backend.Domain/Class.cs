using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class Class 
{
    public uint Id { get; init; }
  
    /// <summary>
    /// Буква класса 
    /// </summary>
    public char Letter { get; set; }
    public Parallel Parallel { get; set; }
    public uint ParallelId { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
}