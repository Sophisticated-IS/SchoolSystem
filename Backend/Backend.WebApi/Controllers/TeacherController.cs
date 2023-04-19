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

    // [Authorize(Roles = "SchoolAdmin")]
    // [Authorize(Roles = "Teacher")]
    // [Authorize(Roles = "Pupil")]
    [HttpGet]
    public async Task<IEnumerable<Application.ApiModels.TeacherWithId>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllTeachersQuery());
    }
    
    // [Authorize(Roles = "SchoolAdmin")]
    // [Authorize(Roles = "Teacher")]
    // [Authorize(Roles = "Pupil")]
    [HttpGet("Filter")]
    public async Task<IEnumerable<Application.ApiModels.TeacherWithId>> GetFilteredTeachers(Application.ApiModels.Teacher teacher)
    {
        return await _mediator.Send(new GetFilteredTeachersQuery(teacher.Name,teacher.SurName,teacher.MiddleName));
    }
    
    // [Authorize(Roles = "SchoolAdmin")]
    // [Authorize(Roles = "Teacher")]
    // [Authorize(Roles = "Pupil")]
    [HttpGet("Pagination")]
    public async Task<IEnumerable<Application.ApiModels.TeacherWithId>> GetPaginationTeachers(uint from,uint to)
    {
        return await _mediator.Send(new GetTeacherPaginationQuery(from,to));
    }
    
    // [Authorize(Roles = "SchoolAdmin")]
    // [Authorize(Roles = "Teacher")]
    // [Authorize(Roles = "Pupil")]
    [HttpGet("{id}")]
    public async Task<TeacherWithId> GetTeacherById(uint id)
    {
        return await _mediator.Send(new GetTeacherByIdQuery(id));
    }
    
    // [Authorize(Roles = "SchoolAdmin")]
    [HttpPost]
    public async Task<TeacherWithId> CreateTeacher(Application.ApiModels.Teacher teacher)
    {
        var createTeacherCmd = _mapper.Map<CreateTeacherCommand>(teacher);
        return await _mediator.Send(createTeacherCmd);
    }

    // [Authorize(Roles = "SchoolAdmin")]
    [HttpPut]
    public async Task<uint[]> UpdateTeacher(uint teacherId,uint[] classIds)  
    {
        var updateTeacherCmd = new UpdateTeacherClassesCommand(teacherId,classIds);
        return await _mediator.Send(updateTeacherCmd);
    }
    
    // [Authorize(Roles = "SchoolAdmin")]
    [HttpDelete]
    public async Task DeleteTeacher(uint teacherId)
    {
        await _mediator.Send(new DeleteTeacherCommand(teacherId));
    }
}