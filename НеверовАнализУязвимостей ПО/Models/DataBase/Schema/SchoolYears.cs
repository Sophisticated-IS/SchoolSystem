using System.ComponentModel.DataAnnotations;

namespace НеверовАнализУязвимостейПО.Models.DataBase.Schema;

public sealed class SchoolYears
{
    [Key]public int Id { get; init; }
    public uint SchoolYear { get; set; }
}