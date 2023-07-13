using ErrorOr;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Domain.Entities;
using MediatR;
using JobBoard.Domain.Common.Errors;

namespace JobBoard.Application.JobOffers.Commands
{
    public class DeleteJobOfferCommandHandler : IRequestHandler<DeleteJobOfferCommand, ErrorOr<Unit>>
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public DeleteJobOfferCommandHandler(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteJobOfferCommand command, CancellationToken cancellationToken)
        {
            JobOffer jobOffer = await _jobOfferRepository.GetJobOfferById(command.Id);
            if (jobOffer == null)
            {
                return Errors.JobOffers.NotFound;
            }

            await _jobOfferRepository.DeleteJobOffer(command.Id);
            return Unit.Value;
        }
    }
}
