using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

internal sealed class GetFilteredTeachersHandler : IRequestHandler<GetFilteredTeachersQuery, IEnumerable<TeacherWithId>>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public GetFilteredTeachersHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeacherWithId>> Handle(
        GetFilteredTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _schoolDbContext.Teachers
                                             .Where(p=>p.Name.Contains(request.Name) 
                                                       || p.SurName.Contains(request.SurName)
                                                       || p.MiddleName.Contains(request.MiddleName))
                                             .ToListAsync(cancellationToken: cancellationToken)
                                             .ConfigureAwait(false);
        return teachers.Select(t => _mapper.Map<TeacherWithId>(t));
    }
}