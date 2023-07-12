using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using MediatR;

namespace JobBoard.Application.JobOffers.Commands
{
    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand, ErrorOr<Unit>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public UpdateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
        {
            await _jobOfferRepository.UpdateJobOffer(request.Id, request.JobOffer);
            return Unit.Value;
        }
    }
}
