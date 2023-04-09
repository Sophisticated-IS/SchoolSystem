using Backend.Application.Queries;
using MediatR;
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
    
    [HttpGet(Name = "GetAllClasses")]
    public async Task<IEnumerable<Application.ApiModels.Class>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllClassesQuery());
    }
    
    [HttpGet("ClassTeachers")]
    public async Task<IEnumerable<uint>> GetClassTeachers(uint classId)
    {
        return await _mediator.Send(new GetClassTeacherQuery(classId));
    }
}