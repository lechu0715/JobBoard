using JobBoard.Application.Services.Authentication.Commands;
using JobBoard.Application.Services.Authentication.Queries;
using JobBoard.Application.Services.JobOffers;
using Microsoft.Extensions.DependencyInjection;

namespace JobBoard.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            services.AddScoped<IJobOfferCommandService, JobOfferCommandService>();
            services.AddScoped<IJobOfferQueryService, JobOfferQueryService>();
            return services;
        }
    }
}
