using AutoMapper;
using Backend.Application.ApiModels;
using Backend.Application.Commands;
using Backend.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
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

    
    [HttpGet(Name = "GetAllTeachers")]
    public async Task<IEnumerable<Application.ApiModels.TeacherWithId>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllTeachersQuery());
    }
    
    [HttpPost(Name = "CreateTeacher")]
    public async Task<TeacherWithId> CreateTeacher(Application.ApiModels.Teacher teacher)
    {
        var createTeacherCmd = _mapper.Map<CreateTeacherCommand>(teacher);
        return await _mediator.Send(createTeacherCmd);
    }
    
    [HttpDelete(Name = "DeleteTeacher")]
    public async Task DeleteTeacher(uint id)
    {
        await _mediator.Send(new DeleteTeacherCommand(id));
    }

}