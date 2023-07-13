using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;
using MediatR;
using JobBoard.Domain.Common.Errors;

namespace JobBoard.Application.JobOffers.Commands
{
    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand, ErrorOr<Unit>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public UpdateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateJobOfferCommand command, CancellationToken cancellationToken)
        {
            JobOffer jobOffer = await _jobOfferRepository.GetJobOfferById(command.Id);
            if (jobOffer == null)
            {
                return Errors.JobOffers.NotFound;
            }

            await _jobOfferRepository.UpdateJobOffer(command.Id, command.JobOffer);
            return Unit.Value;
        }
    }
}
