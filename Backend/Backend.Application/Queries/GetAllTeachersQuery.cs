using MediatR;

namespace Backend.Application.Queries;

public sealed class GetAllTeachersQuery : IRequest<IEnumerable<ApiModels.TeacherWithId>>
{
    
}