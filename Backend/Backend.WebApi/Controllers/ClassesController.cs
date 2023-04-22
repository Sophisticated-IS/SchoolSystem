using Backend.Application.ApiModels;
using Backend.Application.Queries;
using Backend.WebApi.Validation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
    
    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet()]
    public async Task<IActionResult> GetAllClasses()
    {
        var result = await _mediator.Send(new GetAllClassesQuery());
        return Ok(result);
    }
    
    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClassById([NotZero]uint id)
    {
        var result = await _mediator.Send(new GetClassByIdQuery(id));
        return Ok(result);
    }

    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("TeachersInClass")]
    public async Task<IActionResult> GetClassTeachers([NotZero]uint classId)
    {
        var result = await _mediator.Send(new GetClassTeacherQuery(classId));
        return Ok(result);
    }
}