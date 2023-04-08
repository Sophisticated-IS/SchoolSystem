using AutoMapper;
using Backend.Domain;
using MediatR;

namespace Backend.Application.Commands.Handlers;

internal sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand,ApiModels.TeacherWithId>
{
    
    private readonly ISchoolDbContext _schoolDbContext;
    private readonly IMapper _mapper;

    public CreateTeacherCommandHandler(ISchoolDbContext schoolDbContext, IMapper mapper)
    {
        _schoolDbContext = schoolDbContext;
        _mapper = mapper;
    }
    public async Task<ApiModels.TeacherWithId> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = _mapper.Map<Teacher>(request);

        await _schoolDbContext.Teachers.AddAsync(teacher, cancellationToken).ConfigureAwait(false);
        await _schoolDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false); 
        
        var teacherWithId = new  ApiModels.TeacherWithId{Id = teacher.Id};
        return _mapper.Map(request,teacherWithId);
    }
}