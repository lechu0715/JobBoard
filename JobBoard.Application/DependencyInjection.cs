using Microsoft.Extensions.DependencyInjection;
using MediatR;
using JobBoard.Application.Services.JobOffers;

namespace JobBoard.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddScoped<IJobOfferCommandService, JobOfferCommandService>();
            services.AddScoped<IJobOfferQueryService, JobOfferQueryService>();
            return services;
        }
    }
}
