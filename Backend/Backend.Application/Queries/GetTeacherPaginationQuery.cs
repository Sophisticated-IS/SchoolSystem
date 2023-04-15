using Backend.Application.ApiModels;
using MediatR;

namespace Backend.Application.Queries;

public sealed class GetTeacherPaginationQuery : IRequest<IEnumerable<TeacherWithId>>
{
    public uint From { get; }
    public uint To { get; }
    
    public GetTeacherPaginationQuery(uint from, uint to)
    {
        From = from;
        To = to;
    }
}