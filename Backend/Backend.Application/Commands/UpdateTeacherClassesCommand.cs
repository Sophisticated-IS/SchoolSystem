using MediatR;

namespace Backend.Application.Commands;

public sealed class UpdateTeacherClassesCommand : IRequest<uint[]>
{
    public uint[] ClassIds { get; init; }
    public uint TeacherId { get; init; }

    public UpdateTeacherClassesCommand(uint teacherId, uint[] classIds)
    {
        ClassIds = classIds;
        TeacherId = teacherId;
    }
}