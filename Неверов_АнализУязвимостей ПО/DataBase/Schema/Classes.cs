using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class Classes
{
    [Key] public int Id { get; set; }
    public SchoolYears SchoolYearId { get; set; }
    public ClassParallels ClassParallelsId { get; set; }
    public Teachers TeacherId { get; set; }
}