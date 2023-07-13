using JobBoard.API.Controllers;
using JobBoard.Application.JobOffers.Commands;
using JobBoard.Application.JobOffers.Queries;
using JobBoard.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("joboffers")]
public class JobOfferController : ApiController
{
    private readonly IMediator _mediator;

    public JobOfferController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<JobOffer>>> GetAllJobOffers()
    {
        var jobOffers = await _mediator.Send(new GetAllJobOffersQuery());
        return Ok(jobOffers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobOffer>> GetJobOfferById(int id)
    {
        var query = new GetJobOfferByIdQuery(id);
        var jobOffer = await _mediator.Send(query);
        return Ok(jobOffer);
    }

    [HttpPost]
    public async Task<ActionResult> AddJobOffer(JobOffer jobOffer)
    {
        var command = new AddJobOfferCommand(jobOffer);
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateJobOffer(int id, JobOffer jobOffer)
    {
        var command = new UpdateJobOfferCommand(id, jobOffer);
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteJobOffer(int id)
    {
        var command = new DeleteJobOfferCommand(id);
        await _mediator.Send(command);
        return Ok();
    }
}
