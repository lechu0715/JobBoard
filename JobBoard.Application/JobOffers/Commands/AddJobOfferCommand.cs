using ErrorOr;
using JobBoard.Domain.Entities;
using MediatR;

namespace JobBoard.Application.JobOffers.Commands
{
    public record AddJobOfferCommand(JobOffer jobOffer) : IRequest<ErrorOr<Unit>>;
}
