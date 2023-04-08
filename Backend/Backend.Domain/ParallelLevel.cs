using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class ParallelLevel
{
    [Key] public int Id { get; init; }
    public string Level { get; set; }
}