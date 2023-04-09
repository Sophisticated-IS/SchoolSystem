using MediatR;

namespace Backend.Application.Commands;

public sealed class UpdatePupilClassesCommand : IRequest
{
    public uint ClassId { get; init; }
    public uint PupilId { get; init; }

    public UpdatePupilClassesCommand(uint pupilId, uint classId)
    {
        ClassId = classId;
        PupilId = pupilId;
    }
}