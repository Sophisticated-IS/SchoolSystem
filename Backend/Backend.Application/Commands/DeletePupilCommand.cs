using MediatR;

namespace Backend.Application.Commands;

public sealed class DeletePupilCommand : IRequest
{
    public uint PupilId { get; init; }

    public DeletePupilCommand(uint pupilId)
    {
        PupilId = pupilId;
    }
}