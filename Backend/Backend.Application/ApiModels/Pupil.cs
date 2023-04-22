using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class Pupil : IMapWith<Domain.Pupil>
{
    [StringLength(64, MinimumLength = 1)]
    public string Name { get; set; }

    [StringLength(64, MinimumLength = 1)]
    public string SurName { get; set; }
    
    [StringLength(64, MinimumLength = 1)]
    public string MiddleName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Pupil, Domain.Pupil>(MemberList.Source);
        profile.CreateMap<Domain.Pupil, Pupil>(MemberList.Destination);
    }
}