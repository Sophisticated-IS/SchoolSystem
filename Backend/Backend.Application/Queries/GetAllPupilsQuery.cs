using MediatR;

namespace Backend.Application.Queries;

public sealed class GetAllPupilsQuery : IRequest<IEnumerable<ApiModels.Pupil>>
{
    
}