using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class ClassParallels
{
    [Key] public int Id { get; set; }
    public ParallelLevel ParallelLevelId { get; set; }
    public string Parallel { get; set; }
    
}