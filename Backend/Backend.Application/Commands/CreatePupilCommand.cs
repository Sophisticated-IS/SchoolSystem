using AutoMapper;
using Backend.Application.ApiModels;
using Backend.Application.Common.Mappings;
using MediatR;
using Pupil = Backend.Domain.Pupil;

namespace Backend.Application.Commands;

public sealed class CreatePupilCommand : IRequest<PupilWithId>, IMapWith<Pupil>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApiModels.Pupil, CreatePupilCommand>(MemberList.Destination);
        profile.CreateMap<CreatePupilCommand, Domain.Pupil>(MemberList.Source);
        
    }
}