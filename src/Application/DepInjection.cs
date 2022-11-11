using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Servicos.Autenticacoes;
using Application.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DepInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuteServico, AuteServico>();

            return services;
        }
    }
}
