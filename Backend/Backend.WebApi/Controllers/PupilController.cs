using AutoMapper;
using Backend.Application.ApiModels;
using Backend.Application.Commands;
using Backend.Application.Queries;
using Backend.WebApi.Validation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
    public async Task<IActionResult> GetAllPupils()
    {
        var pupilWithIds = await _mediator.Send(new GetAllPupilsQuery());
        return Ok(pupilWithIds);
    }

    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("Filter")]
    public async Task<IActionResult> GetFilteredPupils(
        [FromQuery][ValidateNever]Application.ApiModels.Pupil pupil)
    {
        var pupilWithIds = await _mediator.Send(new GetFilteredPupilsQuery(pupil.Name, pupil.SurName, pupil.MiddleName));
        return Ok(pupilWithIds);
    }

    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("Pagination")]
    public async Task<IActionResult> GetPaginationPupils(uint from, uint to)
    {
        if (from > to)
            return BadRequest($"{from} cannot be greater than {to}");

        var pupilWithIds = await _mediator.Send(new GetPupilPaginationQuery(from, to));
        return Ok(pupilWithIds);
    }


    [Authorize(Roles = "SchoolAdmin,Teacher,Pupil")]
    [HttpGet("{id}/Class")]
    public async Task<IActionResult> GetPupilClass([NotZero]uint id)
    {
        var result = await _mediator.Send(new GetPupilClassByIdQuery(id));
        return Ok(result);
    }

    [Authorize(Roles = "SchoolAdmin,Teacher")]
    [HttpPut]
    public async Task<IActionResult> UpdatePupilClass([NotZero]uint pupilId, [NotZero]uint classId)
    {
        var command = new UpdatePupilClassesCommand(pupilId, classId);
        await _mediator.Send(command);
        
        return Ok();
    }

    [Authorize(Roles = "SchoolAdmin,Teacher")]
    [HttpPost]
    public async Task<IActionResult> CreatePupil(Application.ApiModels.Pupil pupil)
    {
        
        var pupilCommand = _mapper.Map<CreatePupilCommand>(pupil);
        var pupilWithId = await _mediator.Send(pupilCommand);
        return Ok(pupilWithId);
    }

    [Authorize(Roles = "SchoolAdmin")]
    [HttpDelete]
    public async Task<IActionResult> DeletePupil([NotZero]uint pupilId)
    {
        await _mediator.Send(new DeletePupilCommand(pupilId));
        return Ok();
    }
}