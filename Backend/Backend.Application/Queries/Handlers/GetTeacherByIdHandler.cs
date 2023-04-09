using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public sealed class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, TeacherWithId>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public GetTeacherByIdHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }

    public async Task<TeacherWithId> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _schoolDbContext.Teachers.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken: cancellationToken)
                                            .ConfigureAwait(false);
        if (teacher is null) throw new Exception("Teacher not found");
        
        
        return _mapper.Map<TeacherWithId>(teacher);
    }
}