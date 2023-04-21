using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Backend.Application.Commands;
using Backend.Application.Common.Mappings;

namespace Backend.Application.ApiModels;

public sealed class Teacher : IMapWith<Domain.Teacher>,IMapWith<CreateTeacherCommand>
{
    [StringLength(64, MinimumLength = 1)]
    public string Name { get; set; }

    [StringLength(64, MinimumLength = 1)]
    public string SurName { get; set; }
    [StringLength(64, MinimumLength = 1)]
    public string MiddleName { get; set; }
    [MaxLength(512)]
    public string Comment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Teacher,Domain.Teacher>();
        profile.CreateMap<Teacher, CreateTeacherCommand>();
    } 
}