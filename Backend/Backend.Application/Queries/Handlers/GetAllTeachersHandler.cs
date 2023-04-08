using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

internal sealed class GetAllTeachersHandler: IRequestHandler<GetAllTeachersQuery,IEnumerable<Teacher>>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;
    public GetAllTeachersHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Teacher>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _schoolDbContext.Teachers.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        return teachers.Select(t=>_mapper.Map<Teacher>(t));
    }
}