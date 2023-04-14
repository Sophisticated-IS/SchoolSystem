using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public sealed class GetFilteredPupilsHandler : IRequestHandler<GetFilteredPupilsQuery,IEnumerable<PupilWithId>>
{
    
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;
    public GetFilteredPupilsHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<PupilWithId>> Handle(GetFilteredPupilsQuery request, CancellationToken cancellationToken)
    {
        var pupils = await _schoolDbContext.Pupils
                                           .Where(p=>p.Name.Contains(request.Name) 
                                                     || p.SurName.Contains(request.SurName)
                                                     || p.MiddleName.Contains(request.MiddleName))
                                           .ToListAsync(cancellationToken: cancellationToken)
                                           .ConfigureAwait(false);
        
        return pupils.Select(p => _mapper.Map<PupilWithId>(p));
        
    }
}