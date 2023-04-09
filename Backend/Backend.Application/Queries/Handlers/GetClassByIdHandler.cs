using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public sealed class GetClassByIdHandler : IRequestHandler<GetClassByIdQuery,Class>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;
    
    public GetClassByIdHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }
    public async Task<Class> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
    {
        var pupilClass = await _schoolDbContext.Classes.Include(c=>c.Parallel).FirstOrDefaultAsync((p) => p.Id == request.Id, cancellationToken);
        if (pupilClass is null) throw new Exception("Class not found");
        
        
        return new Class
        {
            Id = pupilClass.Id,
            Letter= pupilClass.Letter,
            Number = pupilClass.Parallel.Number
        };
    }
}