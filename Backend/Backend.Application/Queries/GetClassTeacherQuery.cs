using MediatR;

namespace Backend.Application.Queries;

public sealed class GetClassTeacherQuery : IRequest<uint[]>
{
    public uint ClassId { get; init; }

    public GetClassTeacherQuery(uint classId )
    {
        ClassId = classId;
    }
}