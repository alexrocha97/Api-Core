using Application.Common.Interfaces.Autenticacao;
using Application.Common.Interfaces.Pesistencia;
using Application.Common.Interfaces.Services;
using Infra.Pesistencia;
using Infra.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DepenInjection
    {
        public static IServiceCollection AddInfra(
            this IServiceCollection services,
            ConfigurationManager configuratio
            )
        {
            services.Configure<JwtSettings>(configuratio.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
