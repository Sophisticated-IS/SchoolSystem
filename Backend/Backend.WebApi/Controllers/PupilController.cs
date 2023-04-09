using AutoMapper;
using Backend.Application.Commands;
using Backend.Application.Queries;
using MediatR;
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
     
    [HttpGet]
    public async Task<IEnumerable<Application.ApiModels.PupilWithId>> GetAllTeachers()
    {
        return await _mediator.Send(new GetAllPupilsQuery());
    }
    
    [HttpPut]
    public async void  Task(uint pupilId,uint classId)  
    {
        var command = new UpdatePupilClassesCommand(pupilId,classId);
        await _mediator.Send(command);
    }
    
    [HttpPost]
    public async Task<Application.ApiModels.PupilWithId> CreatePupil(Application.ApiModels.Pupil pupil)
    {
        var pupilCommand = _mapper.Map<CreatePupilCommand>(pupil);
        return await _mediator.Send(pupilCommand);
    }
    
    [HttpDelete]
    public async Task DeletePupil(uint id)
    {
        await _mediator.Send(new DeletePupilCommand(id));
    }
}