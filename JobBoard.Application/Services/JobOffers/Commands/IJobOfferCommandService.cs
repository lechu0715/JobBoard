using JobBoard.Domain.Entities;

namespace JobBoard.Application.Services.JobOffers
{
    public interface IJobOfferCommandService
    {
        Task AddJobOffer(JobOffer jobOffer);
        Task UpdateJobOffer(int id, JobOffer jobOffer);
        Task DeleteJobOffer(int id);
    }
}
