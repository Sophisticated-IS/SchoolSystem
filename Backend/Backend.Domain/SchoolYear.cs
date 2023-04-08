using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

/// <summary>
/// Учебный года
/// </summary>
public sealed class SchoolYear
{
    public uint Id { get; init; }
    public ushort Year { get; set; }
}