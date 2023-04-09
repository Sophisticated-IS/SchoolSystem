using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

internal sealed class GetAllClassesHandler : IRequestHandler<GetAllClassesQuery, IEnumerable<Class>>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public GetAllClassesHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _schoolDbContext = schoolDbContext;
    }

    public async Task<IEnumerable<Class>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        var classes = await _schoolDbContext.Classes.Include(c=>c.Parallel).ToListAsync(cancellationToken: cancellationToken)
                                            .ConfigureAwait(false);
        return classes.Select(c => new Class
        {
            Id = c.Id,
            Letter= c.Letter,
            Number = c.Parallel.Number
        });
    }
}