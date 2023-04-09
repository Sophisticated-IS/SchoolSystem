using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public sealed class GetClassTeacherHandler : IRequestHandler<GetClassTeacherQuery, uint[]>
{
    private readonly ISchoolDbContext _schoolDbContext;


    public GetClassTeacherHandler(ISchoolDbContext schoolDbContext)
    {
        _schoolDbContext = schoolDbContext;
    }
    
    public async Task<uint[]> Handle(GetClassTeacherQuery request, CancellationToken cancellationToken)
    {
        var classTeacher = await _schoolDbContext.Classes
                                                 .Include(p=>p.Teachers)
                                                 .FirstOrDefaultAsync(ct => ct.Id == request.ClassId, cancellationToken: cancellationToken);
        if (classTeacher is null) return Array.Empty<uint>();
        
        
        return classTeacher.Teachers.Select(t=>t.Id).ToArray();
        
    }
}