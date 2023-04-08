using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

public sealed class Classes : IEquatable<Classes>
{
    [Key] public int Id { get; init; }
    public int SchoolYearId { get; set; }
    public SchoolYears SchoolYear { get; set; }
    public int ClassParallelsId { get; set; }
    public ClassParallels ClassParallel { get; set; }
    public int TeacherId { get; set; }
    public Teachers Teacher { get; set; }

    public bool Equals(Classes? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Classes other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}