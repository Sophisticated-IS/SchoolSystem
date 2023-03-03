namespace Неверов_АнализУязвимостей_ПО.Models.DTO;

internal sealed class PupilDto : IEquatable<PupilDto>
{
    public string FIO { get; set; }
    public int ClassId { get; set; }

    public bool Equals(PupilDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return FIO == other.FIO && ClassId == other.ClassId;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is PupilDto other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FIO, ClassId);
    }
}