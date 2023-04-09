using Backend.Application.ApiModels;
using MediatR;

namespace Backend.Application.Queries;

public sealed class GetTeacherByIdQuery : IRequest<TeacherWithId>
{
    public uint Id { get; init; }

    public GetTeacherByIdQuery(uint id)
    {
        Id = id;
    }

}