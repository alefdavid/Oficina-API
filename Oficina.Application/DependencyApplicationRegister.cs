using Microsoft.Extensions.DependencyInjection;
using OficinaOS.Application.Services;
using OficinaOS.Domain;
using OficinaOS.Domain.Interfaces.Services;

namespace OficinaOS.Application
{
    public static class DependencyApplicationRegister
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPecaService, PecaService>();

            return services;
        }
    }
}
