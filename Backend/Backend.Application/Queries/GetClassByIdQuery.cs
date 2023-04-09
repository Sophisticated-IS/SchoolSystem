using Backend.Application.ApiModels;
using MediatR;

namespace Backend.Application.Queries;

public sealed class GetClassByIdQuery : IRequest<Class>
{
    public uint Id { get; init; }

    public GetClassByIdQuery(uint id)
    {
        Id = id;
    }
}