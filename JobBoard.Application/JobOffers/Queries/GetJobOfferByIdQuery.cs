using ErrorOr;
using JobBoard.Domain.Entities;
using MediatR;

namespace JobBoard.Application.JobOffers.Queries
{
    public record GetJobOfferByIdQuery(int Id) : IRequest<ErrorOr<JobOffer>>;
}
