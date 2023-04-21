using AutoMapper;
using Backend.Application.ApiModels;
using Backend.Application.Commands;
using Backend.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet]
    public async Task<IActionResult> GetAllTeachers()
    {
        var teacherWithIds = await _mediator.Send(new GetAllTeachersQuery());
        return Ok(teacherWithIds);
    }
    
    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("Filter")]
    public async Task<IActionResult> GetFilteredTeachers([FromQuery]Application.ApiModels.Teacher teacher)
    {
        var teacherWithIds = await _mediator.Send(new GetFilteredTeachersQuery(teacher.Name,teacher.SurName,teacher.MiddleName));
        return Ok(teacherWithIds);
    }
    
    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("Pagination")]
    public async Task<IActionResult> GetPaginationTeachers(uint from,uint to)
    {
        var teacherWithIds = await _mediator.Send(new GetTeacherPaginationQuery(from,to));
        return Ok(teacherWithIds);
    }
    
    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacherById(uint id)
    {
        var teacherWithId = await _mediator.Send(new GetTeacherByIdQuery(id));
        return Ok(teacherWithId);
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [HttpPost]
    public async Task<IActionResult> CreateTeacher(Application.ApiModels.Teacher teacher)
    {
        var createTeacherCmd = _mapper.Map<CreateTeacherCommand>(teacher);
        var teacherWithId = await _mediator.Send(createTeacherCmd);
        return Ok(teacherWithId);
    }

    [Authorize(Roles = "SchoolAdmin")]
    [HttpPut]
    public async Task<IActionResult> UpdateTeacher(uint teacherId,uint[] classIds)  
    {
        var updateTeacherCmd = new UpdateTeacherClassesCommand(teacherId,classIds);
        var result = await _mediator.Send(updateTeacherCmd);
        return Ok(result);
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [HttpDelete]
    public async Task<IActionResult> DeleteTeacher(uint teacherId)
    {
        await _mediator.Send(new DeleteTeacherCommand(teacherId));
        return Ok();
    }
}