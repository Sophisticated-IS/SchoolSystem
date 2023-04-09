using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Commands.Handlers;

public sealed class UpdateTeacherClassesCommandHandler : IRequestHandler<UpdateTeacherClassesCommand,uint[]>
{
    private readonly ISchoolDbContext _schoolDbContext;
        
    public UpdateTeacherClassesCommandHandler(ISchoolDbContext schoolDbContext)
    {
        _schoolDbContext = schoolDbContext;
    }

    public async Task<uint[]> Handle(UpdateTeacherClassesCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _schoolDbContext.Teachers.FirstOrDefaultAsync((t) => t.Id == request.TeacherId, cancellationToken);
        if (teacher is null) return Array.Empty<uint>();

        var hashIds = request.ClassIds.ToHashSet();
        var classes = _schoolDbContext.Classes.Where(c => hashIds.Contains(c.Id));

        teacher.Classes = classes.ToList();

        await _schoolDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        return classes.Select(c => c.Id).ToArray();
    }
}