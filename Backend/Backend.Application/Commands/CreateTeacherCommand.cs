using AutoMapper;
using Backend.Application.ApiModels;
using Backend.Application.Common.Mappings;
using MediatR;

namespace Backend.Application.Commands;

public sealed class CreateTeacherCommand : IRequest<ApiModels.TeacherWithId>, IMapWith<Domain.Teacher>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
    public string Comment { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTeacherCommand, Domain.Teacher>(MemberList.Source);
        profile.CreateMap<CreateTeacherCommand, TeacherWithId>(MemberList.Source);
    }
}