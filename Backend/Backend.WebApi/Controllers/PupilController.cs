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

    public PupilController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet]
    public async Task<IEnumerable<Application.ApiModels.PupilWithId>> GetAllPupils()
    {
        return await _mediator.Send(new GetAllPupilsQuery());
    }

    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("Filter")]
    public async Task<IEnumerable<Application.ApiModels.PupilWithId>> GetFilteredPupils(
        Application.ApiModels.Pupil pupil)
    {
        return await _mediator.Send(new GetFilteredPupilsQuery(pupil.Name, pupil.SurName, pupil.MiddleName));
    }

    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("Pagination")]
    public async Task<IEnumerable<Application.ApiModels.PupilWithId>> GetPaginationPupils(uint from, uint to)
    {
        return await _mediator.Send(new GetPupilPaginationQuery(from, to));
    }


    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("{id}/Class")]
    public async Task<Class> GetPupilClass(uint id)
    {
        return await _mediator.Send(new GetPupilClassByIdQuery(id));
    }

    [Authorize(Roles = "SchoolAdmin,Teacher")]
    [HttpPut]
    public async Task UpdatePupilClass(uint pupilId, uint classId)
    {
        var command = new UpdatePupilClassesCommand(pupilId, classId);
        await _mediator.Send(command);
    }

    [Authorize(Roles = "SchoolAdmin,Teacher")]
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