using App;
using CrossCutting;
using Domain;
using Domain.Servicos;
using Infra;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Xml.Linq;

namespace BCB_DOC4111_SaldoDiario // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dependencias = ConfiguraServicos();
                
            var app = dependencias.GetService<IGerarXML>();

            if (app.startApp())
            {
                Console.WriteLine(("XML Gerado com sucesso"));
            }
            else
            {
                Console.WriteLine(("XML deu merda"));
            }
        }

        private static ServiceProvider ConfiguraServicos()
        {
            var services = new  ServiceCollection();
            services.AddDependencies();
            return services.BuildServiceProvider();
        }

    }

}