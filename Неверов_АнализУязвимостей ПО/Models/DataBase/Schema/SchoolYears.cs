using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.Models.DataBase.Schema;

public sealed class SchoolYears
{
    [Key]public int Id { get; init; }
    public uint SchoolYear { get; set; }
}