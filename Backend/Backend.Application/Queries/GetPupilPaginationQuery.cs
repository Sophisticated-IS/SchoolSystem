using Backend.Application.ApiModels;
using MediatR;

namespace Backend.Application.Queries;

public sealed class GetPupilPaginationQuery : IRequest<IEnumerable<PupilWithId>>
{
    public uint From { get; }
    public uint To { get; }

    public GetPupilPaginationQuery(uint from, uint to)
    {
        From = from;
        To = to;
    }
}