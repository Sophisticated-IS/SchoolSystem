using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class Teacher : IMapWith<Domain.Teacher>
{
    public uint Id { get; init; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
    public string Comment { get; set; }
}