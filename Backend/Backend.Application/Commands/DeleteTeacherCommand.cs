using MediatR;

namespace Backend.Application.Commands;

public sealed class DeleteTeacherCommand : IRequest
{
    public uint Id { get; init; }

    public DeleteTeacherCommand(uint id)
    {
        Id = id;
    }
}