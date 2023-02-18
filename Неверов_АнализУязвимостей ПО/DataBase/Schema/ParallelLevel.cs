using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class ParallelLevel
{
    [Key] public int Id { get; set; }
    public string Level { get; set; }
}