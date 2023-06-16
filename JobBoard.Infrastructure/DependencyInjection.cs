using JobBoard.Application.Common.Interfaces.Authentication;
using JobBoard.Application.Common.Interfaces.Persistence;
using JobBoard.Application.Common.Interfaces.Services;
using JobBoard.Infrastructure.Authentication;
using JobBoard.Infrastructure.Persistence;
using JobBoard.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JobBoard.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            return services;
        }
    }
}
