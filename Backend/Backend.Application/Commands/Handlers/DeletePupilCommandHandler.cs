using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Commands.Handlers;

public sealed class DeletePupilCommandHandler : IRequestHandler<DeletePupilCommand>
{
    private readonly ISchoolDbContext _schoolDbContext;

    public DeletePupilCommandHandler(ISchoolDbContext schoolDbContext)
    {
        _schoolDbContext = schoolDbContext;
    }

    public async Task Handle(DeletePupilCommand request, CancellationToken cancellationToken)
    {
        var pupil = await _schoolDbContext.Pupils.FirstOrDefaultAsync(p=>p.Id == request.PupilId, cancellationToken).ConfigureAwait(false);
        if (pupil is null) return;
        
        _schoolDbContext.Pupils.Remove(pupil);
        await _schoolDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}