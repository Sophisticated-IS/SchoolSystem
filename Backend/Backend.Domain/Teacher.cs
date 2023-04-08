using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

/// <summary>
/// Учителя
/// </summary>
public sealed class Teacher
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
    public string Comment { get; set; }
    public ICollection<Class> Classes { get; set; }
}