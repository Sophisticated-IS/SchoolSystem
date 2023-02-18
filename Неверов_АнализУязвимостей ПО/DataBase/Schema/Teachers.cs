using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class Teachers
{
    [Key]public int Id { get; set; }
    public string FIO { get; set; }
    public string Comment { get; set; }
}