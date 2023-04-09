using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

internal sealed class GetAllPupilsHandler : IRequestHandler<GetAllPupilsQuery, IEnumerable<PupilWithId>>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public GetAllPupilsHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PupilWithId>> Handle(GetAllPupilsQuery request, CancellationToken cancellationToken)
    {
        var pupils =  await _schoolDbContext.Pupils.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        return pupils.Select(p=>_mapper.Map<PupilWithId>(p));  
    }
}