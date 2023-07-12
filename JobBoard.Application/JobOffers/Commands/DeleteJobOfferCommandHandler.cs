using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using MediatR;

namespace JobBoard.Application.JobOffers.Commands
{
    public class DeleteJobOfferCommandHandler : IRequestHandler<DeleteJobOfferCommand, ErrorOr<Unit>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public DeleteJobOfferCommandHandler(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteJobOfferCommand request, CancellationToken cancellationToken)
        {
            await _jobOfferRepository.DeleteJobOffer(request.Id);
            return Unit.Value;
        }
    }
}
