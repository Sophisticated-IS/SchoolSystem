using AutoMapper;
using Backend.Application.Commands;
using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class Teacher : IMapWith<Domain.Teacher>,IMapWith<CreateTeacherCommand>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
    public string Comment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Teacher,Domain.Teacher>();
        profile.CreateMap<Teacher, CreateTeacherCommand>();
    } 
}