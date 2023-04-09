using Backend.Application.ApiModels;
using MediatR;

namespace Backend.Application.Queries;

public sealed class GetAllClassesQuery : IRequest<IEnumerable<Class>>
{
}