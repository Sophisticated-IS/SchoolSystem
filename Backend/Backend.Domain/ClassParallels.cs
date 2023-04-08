using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class ClassParallels
{
    [Key] public int Id { get; init; }
    public ParallelLevel ParallelLevelId { get; set; }
    public string Parallel { get; set; }
    
}