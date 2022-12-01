using Application.Servicos.Autenticacoes.Commamd;
using Application.Servicos.Autenticacoes.Queries;
using Application.Servicos.Interfaces.Commamd;
using Application.Servicos.Interfaces.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DepInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuteQueryServico, AuteQueryServico>();
            services.AddScoped<IAuteCommandServico, AuteCommandServico>();

            return services;
        }
    }
}
