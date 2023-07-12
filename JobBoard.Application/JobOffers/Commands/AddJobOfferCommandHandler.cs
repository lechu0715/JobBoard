using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using MediatR;

namespace JobBoard.Application.JobOffers.Commands
{
    public class AddJobOfferCommandHandler : IRequestHandler<AddJobOfferCommand, ErrorOr<Unit>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public AddJobOfferCommandHandler(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(AddJobOfferCommand command, CancellationToken cancellationToken)
        {
            await _jobOfferRepository.AddJobOffer(command.jobOffer);
            return Unit.Value;
        }
    }
}
