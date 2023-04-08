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

    public TeacherController(ILogger<TeacherController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    
    [HttpGet(Name = "GetAllTeachers")]
    public async Task<IEnumerable<Application.ApiModels.Teacher>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllTeachersQuery());
    }
}