using App;
using Domain;
using Domain.Servicos;
using Infra;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting
{
    public static class DependencyInjection
    {
        public  static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITransacaoRepository, TransacaoRepository>();
            services.AddSingleton<ITransacaoWrite, TransacaoWrite>();
            services.AddSingleton<IServicoConta, ServicoConta>();
            services.AddSingleton<IGerarXML, AppGerarXML>();
            return services;
        }

    }
}