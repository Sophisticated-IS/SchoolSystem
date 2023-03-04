using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.Models.DataBase.Schema;

public sealed class Teachers
{
    [Key]public int Id { get; init; }
    public string FIO { get; set; }
    public string Comment { get; set; }
}