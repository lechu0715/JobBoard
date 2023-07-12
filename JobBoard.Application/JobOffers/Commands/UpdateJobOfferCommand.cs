using ErrorOr;
using JobBoard.Domain.Entities;
using MediatR;

namespace JobBoard.Application.JobOffers.Commands
{
    public record UpdateJobOfferCommand(int Id, JobOffer JobOffer) : IRequest<ErrorOr<Unit>>;


}
