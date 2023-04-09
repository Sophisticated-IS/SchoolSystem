using Backend.Domain;
using MediatR;
using Class = Backend.Application.ApiModels.Class;

namespace Backend.Application.Queries;

public sealed class GetPupilClassByIdQuery : IRequest<Class>
{
    public uint PupilId { get; init; }

    public GetPupilClassByIdQuery(uint pupilId)
    {
        PupilId = pupilId;
    }
}