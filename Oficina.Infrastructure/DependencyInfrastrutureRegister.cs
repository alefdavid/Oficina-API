using Microsoft.Extensions.DependencyInjection;
using OficinaOS.Domain;
using OficinaOS.Domain.Interfaces.Repositories;

namespace OficinaOS.Infrastructure.Repositories
{
    public static class DependencyInfrastrutureRegister
    {
        public static IServiceCollection RegisterInfrastrutureDependencies(this IServiceCollection services)
        {

            // Repositories
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPecaRepository, PecaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            return services;
        }
    }
}
