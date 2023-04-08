using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class SchoolYears
{
    [Key]public int Id { get; init; }
    public uint SchoolYear { get; set; }
}