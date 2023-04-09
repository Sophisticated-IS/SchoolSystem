using AutoMapper;
using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class Class : IMapWith<Domain.Class>
{
    public uint Id { get; init; }
    public char Letter { get; set; }
    public byte Number { get; init; }

    public void Map(Profile profile)
    {
        profile.CreateMap<Domain.Class, Class>(MemberList.Destination);
        profile.CreateMap<Class, Domain.Class>(MemberList.Source);
    }
}