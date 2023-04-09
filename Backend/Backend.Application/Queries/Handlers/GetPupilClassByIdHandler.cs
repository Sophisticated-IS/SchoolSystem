using AutoMapper;
using Backend.Application.ApiModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public sealed class GetPupilClassByIdHandler : IRequestHandler<GetPupilClassByIdQuery, Class>
{
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public GetPupilClassByIdHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }

    public async Task<Class> Handle(GetPupilClassByIdQuery request, CancellationToken cancellationToken)
    {
        var pupil = await _schoolDbContext.Pupils.Where(p => p.Id == request.PupilId)
                                          .Include(p => p.Class).ThenInclude(c=>c.Parallel)
                                          .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (pupil is null) throw new Exception("Pupil not found");

        return new Class
        {
            Id = pupil.Class.Id,
            Letter = pupil.Class.Letter,
            Number = pupil.Class.Parallel.Number
        };
    }
}