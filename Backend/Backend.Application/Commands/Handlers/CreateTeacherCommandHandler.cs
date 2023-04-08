using AutoMapper;
using Backend.Domain;
using MediatR;

namespace Backend.Application.Commands.Handlers;

internal sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand,ApiModels.Teacher>
{
    
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public CreateTeacherCommandHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }
    public async Task<ApiModels.Teacher> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    { 
        var teacher = new Teacher()
        {
            Name = request.Name,
            SurName = request.SurName,
            MiddleName = request.MiddleName,
            Comment = request.Comment
        };
        
        await _schoolDbContext.Teachers.AddAsync(teacher, cancellationToken).ConfigureAwait(false);
        await _schoolDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
       
        return _mapper.Map<ApiModels.Teacher>(teacher);
    }
}