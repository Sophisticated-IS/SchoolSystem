using System.ComponentModel.DataAnnotations;

namespace НеверовАнализУязвимостейПО.Models.DataBase.Schema;

public sealed class Teachers
{
    [Key]public int Id { get; init; }
    public string FIO { get; set; }
    public string Comment { get; set; }
}