using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public sealed class GetTeacherPaginationHandler : IRequestHandler<GetTeacherPaginationQuery,IEnumerable<TeacherWithId>>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public GetTeacherPaginationHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeacherWithId>> Handle(GetTeacherPaginationQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _schoolDbContext.Teachers.Skip((int)request.From).Take((int)(request.To - request.From)).ToListAsync(cancellationToken: cancellationToken);
        return teachers.Select(t=>_mapper.Map<TeacherWithId>(t));
    }
}