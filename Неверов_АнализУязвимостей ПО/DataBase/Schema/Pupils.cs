using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class Pupils
{
    [Key] public int Id { get; set; }
    public Classes ClassId { get; set; }
    public string FIO { get; set; }
}