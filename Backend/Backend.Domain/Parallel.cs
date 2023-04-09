using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class Parallel
{
    public uint Id { get; init; }
    
    /// <summary>
    /// Номер параллели
    /// </summary>
    public byte Number { get; init; }

    public uint SchoolYearId { get; set; }
    public SchoolYear SchoolYear { get; set; }

    public ICollection<Class> Classes { get; set; }
}