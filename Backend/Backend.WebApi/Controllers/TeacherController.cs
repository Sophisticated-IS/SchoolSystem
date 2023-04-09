using AutoMapper;
using Backend.Application.ApiModels;
using Backend.Application.Commands;
using Backend.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
  
    private readonly ILogger<TeacherController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TeacherController(ILogger<TeacherController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    
    [HttpGet]
    public async Task<IEnumerable<Application.ApiModels.TeacherWithId>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllTeachersQuery());
    }
    
    [HttpGet("{id}")]
    public async Task<TeacherWithId> GetTeacherById(uint id)
    {
        return await _mediator.Send(new GetTeacherByIdQuery(id));
    }
    
    [HttpPost]
    public async Task<TeacherWithId> CreateTeacher(Application.ApiModels.Teacher teacher)
    {
        var createTeacherCmd = _mapper.Map<CreateTeacherCommand>(teacher);
        return await _mediator.Send(createTeacherCmd);
    }

    [HttpPut]
    public async Task<uint[]> UpdateTeacher(uint teacherId,uint[] classIds)  
    {
        var updateTeacherCmd = new UpdateTeacherClassesCommand(teacherId,classIds);
        return await _mediator.Send(updateTeacherCmd);
    }
    
    [HttpDelete]
    public async Task DeleteTeacher(uint teacherId)
    {
        await _mediator.Send(new DeleteTeacherCommand(teacherId));
    }
}