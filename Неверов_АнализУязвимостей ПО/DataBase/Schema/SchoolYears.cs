using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class SchoolYears
{
    [Key]public int Id { get; set; }
    public uint SchoolYear { get; set; }
}