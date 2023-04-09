using AutoMapper;
using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class Pupil : IMapWith<Domain.Pupil>
{
    public uint Id { get; init; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Pupil,Domain.Pupil>(MemberList.Source);
        profile.CreateMap<Domain.Pupil, Pupil>(MemberList.Destination);
    }
}