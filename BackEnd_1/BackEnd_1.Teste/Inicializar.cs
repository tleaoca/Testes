using BackEnd_1.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_1.Teste
{
    public class Inicializar
    {
        public ServiceProvider ProvedorServico { get; private set; }
        public IConfiguration configuracao { get; }

        public Inicializar()
        {
            var servicos = new ServiceCollection();

            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true);

            builder.AddEnvironmentVariables();
            configuracao = builder.Build();
            
            RegistrarServicos(servicos);

            ProvedorServico = servicos.BuildServiceProvider();
        }

        private static void RegistrarServicos(IServiceCollection servicos)
        {
            InjecaoDependencia.RegistrarServicos(servicos);
           
        }
    }
}
