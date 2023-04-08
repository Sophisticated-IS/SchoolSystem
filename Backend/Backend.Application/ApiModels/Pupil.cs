using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class Pupil : IMapWith<Domain.Pupil>
{
    public uint Id { get; init; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
}