using Application.Common.Interfaces.Autenticacao;
using Application.Common.Interfaces.Services;
using Infra.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DepenInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
