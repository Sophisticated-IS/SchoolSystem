using AutoMapper;
using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class TeacherWithId : IMapWith<Domain.Teacher>
{
    public uint Id { get; init; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
    public string Comment { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Teacher, TeacherWithId>(MemberList.Source);
        profile.CreateMap<TeacherWithId, Domain.Teacher>(MemberList.Destination);
    }
}