using Backend.Application.ApiModels;
using Backend.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController : Controller
{
    private readonly IMediator _mediator;

    public ClassesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [Authorize(Roles = "Teacher")]
    [Authorize(Roles = "Pupil")]
    [HttpGet()]
    public async Task<IEnumerable<Application.ApiModels.Class>> GetAllClasses()
    {
        return await _mediator.Send(new GetAllClassesQuery());
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [Authorize(Roles = "Teacher")]
    [Authorize(Roles = "Pupil")]
    [HttpGet("{id}")]
    public async Task<Class> GetClassById(uint id)
    {
        return await _mediator.Send(new GetClassByIdQuery(id));
    }

    [Authorize(Roles = "SchoolAdmin")]
    [Authorize(Roles = "Teacher")]
    [Authorize(Roles = "Pupil")]
    [HttpGet("TeachersInClass")]
    public async Task<IEnumerable<uint>> GetClassTeachers(uint classId)
    {
        return await _mediator.Send(new GetClassTeacherQuery(classId));
    }
}