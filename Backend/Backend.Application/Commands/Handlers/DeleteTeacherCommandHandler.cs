using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Commands.Handlers;

public sealed class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
{
    private readonly ISchoolDbContext _schoolDbContext;

    public DeleteTeacherCommandHandler(ISchoolDbContext schoolDbContext)
    {
        _schoolDbContext = schoolDbContext;
    }

    public async Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _schoolDbContext.Teachers.FirstOrDefaultAsync((t)=>t.Id == request.Id, cancellationToken);
        if (teacher is null) return;
        
        _schoolDbContext.Teachers.Remove(teacher);
        await _schoolDbContext.SaveChangesAsync(cancellationToken);
    }
}