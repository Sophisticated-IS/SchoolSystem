using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Commands.Handlers;

public sealed class UpdatePupilClassesCommandHandler : IRequestHandler<UpdatePupilClassesCommand>
{
    private readonly ISchoolDbContext _schoolDbContext;
    
    
    public UpdatePupilClassesCommandHandler(ISchoolDbContext schoolDbContext)
    {
        _schoolDbContext = schoolDbContext;
    }
    public async Task Handle(UpdatePupilClassesCommand request, CancellationToken cancellationToken)
    {
        var pupil = await _schoolDbContext.Pupils.FirstOrDefaultAsync((p) => p.Id == request.PupilId, cancellationToken);
        if (pupil is null) throw new Exception("Pupil not found");


        var pupilClass = await _schoolDbContext.Classes.Where(c => c.Id == request.ClassId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (pupilClass is null) throw new Exception("Class not found");
        
        pupil.Class = pupilClass;

        await _schoolDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}