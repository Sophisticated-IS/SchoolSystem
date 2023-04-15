namespace НеверовАнализУязвимостейПО.Models.DTO;

internal sealed class ClassDto : IEquatable<ClassDto>
{
    public int ParallelId { get; set; }
    public string Parallel { get; set; }
    public int TeacherId { get; set; }
    public string TeacherFIO { get; set; }
    public string TeacherComment { get; set; }

    public bool Equals(ClassDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return ParallelId == other.ParallelId;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is ClassDto other && Equals(other);
    }

    public override int GetHashCode()
    {
        return ParallelId;
    }
}