﻿using JobBoard.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace JobBoard.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
