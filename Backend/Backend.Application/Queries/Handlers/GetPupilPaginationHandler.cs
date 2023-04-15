using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public sealed class GetPupilPaginationHandler : IRequestHandler<GetPupilPaginationQuery,IEnumerable<PupilWithId>>
{
    private readonly IMapper _mapper;
    private readonly ISchoolDbContext _schoolDbContext;
    
    public GetPupilPaginationHandler(IMapper mapper, ISchoolDbContext schoolDbContext)
    {
        _mapper = mapper;
        _schoolDbContext = schoolDbContext;
    }
    public async Task<IEnumerable<PupilWithId>> Handle(GetPupilPaginationQuery request, CancellationToken cancellationToken)
    {
        var pupils = await _schoolDbContext.Pupils.Skip((int)request.From).Take((int)(request.To - request.From)).ToListAsync(cancellationToken: cancellationToken);
        return pupils.Select(p=>_mapper.Map<PupilWithId>(p));  
    }
}