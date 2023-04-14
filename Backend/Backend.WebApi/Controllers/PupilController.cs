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
public class PupilController : Controller
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public PupilController(IMediator mediator,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [Authorize(Roles = "Teacher")]
    [Authorize(Roles = "Pupil")]
    [HttpGet]
    public async Task<IEnumerable<Application.ApiModels.PupilWithId>> GetAllPupils()
    {
        return await _mediator.Send(new GetAllPupilsQuery());
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [Authorize(Roles = "Teacher")]
    [Authorize(Roles = "Pupil")]
    [HttpGet("{id}/Class")]
    public async Task<Class> GetPupilClass(uint id)
    {
        return await _mediator.Send(new GetPupilClassByIdQuery(id));
    }

    [Authorize(Roles = "SchoolAdmin")]
    [Authorize(Roles = "Teacher")]
    [HttpPut]
    public async Task UpdatePupilClass(uint pupilId,uint classId)  
    {
        var command = new UpdatePupilClassesCommand(pupilId,classId);
        await _mediator.Send(command);
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [Authorize(Roles = "Teacher")]
    [HttpPost]
    public async Task<Application.ApiModels.PupilWithId> CreatePupil(Application.ApiModels.Pupil pupil)
    {
        var pupilCommand = _mapper.Map<CreatePupilCommand>(pupil);
        return await _mediator.Send(pupilCommand);
    }
    
    [Authorize(Roles = "SchoolAdmin")]
    [HttpDelete]
    public async Task DeletePupil(uint pupilId)
    {
        await _mediator.Send(new DeletePupilCommand(pupilId));
    }
}