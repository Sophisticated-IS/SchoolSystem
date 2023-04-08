using Backend.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PupilController : Controller
{

    private readonly IMediator _mediator;
    public PupilController(IMediator mediator)
    {
        _mediator = mediator;
    }
     
    [HttpGet(Name = "GetAllPupils")]
    public async Task<IEnumerable<Application.ApiModels.Pupil>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllPupilsQuery());
    }
}