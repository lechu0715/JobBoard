using ErrorOr;
using JobBoard.Domain.Entities;
using MediatR;

namespace JobBoard.Application.JobOffers.Queries
{
    public record GetAllJobOffersQuery : IRequest<ErrorOr<List<JobOffer>>>;
}
