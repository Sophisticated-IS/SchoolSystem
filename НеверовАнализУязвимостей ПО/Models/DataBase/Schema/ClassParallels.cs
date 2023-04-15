using System.ComponentModel.DataAnnotations;

namespace НеверовАнализУязвимостейПО.Models.DataBase.Schema;

public sealed class ClassParallels
{
    [Key] public int Id { get; init; }
    public ParallelLevel ParallelLevelId { get; set; }
    public string Parallel { get; set; }
    
}