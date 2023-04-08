using MediatR;

namespace Backend.Application.Commands;

public sealed class CreateTeacherCommand : IRequest<ApiModels.Teacher>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
    public string Comment { get; set; }
}