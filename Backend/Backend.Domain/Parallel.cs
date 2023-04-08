using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class Parallel
{
    public int Id { get; init; }
    
    /// <summary>
    /// Номер параллели
    /// </summary>
    public byte Number { get; init; }
    
    public SchoolYear SchoolYear { get; set; }
}