using ErrorOr;
using MediatR;

namespace JobBoard.Application.JobOffers.Commands
{
    public record DeleteJobOfferCommand(int Id) : IRequest<ErrorOr<Unit>>;

}
