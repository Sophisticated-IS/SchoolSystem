using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;

namespace Backend.Application.Commands.Handlers;

internal sealed class CreatePupilCommandHandler : IRequestHandler<CreatePupilCommand,PupilWithId>
{
    
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;
    
    public CreatePupilCommandHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }
    public async Task<PupilWithId> Handle(CreatePupilCommand request, CancellationToken cancellationToken)
    {
        var domainPupil = _mapper.Map<Domain.Pupil>(request);
        _schoolDbContext.Pupils.Add(domainPupil);
        await _schoolDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return _mapper.Map<PupilWithId>(domainPupil);
    }
    
    
}