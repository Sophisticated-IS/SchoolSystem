using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class Teachers
{
    [Key]public int Id { get; init; }
    public string FIO { get; set; }
    public string Comment { get; set; }
}