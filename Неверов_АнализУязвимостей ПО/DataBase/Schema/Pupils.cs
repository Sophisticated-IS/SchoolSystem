using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class Pupils : IEquatable<Pupils>
{
    [Key] public int Id { get; init; }
    public Classes Class { get; set; }
    public int ClassId { get; set; }
    public string FIO { get; set; }

    public bool Equals(Pupils? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Pupils other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}