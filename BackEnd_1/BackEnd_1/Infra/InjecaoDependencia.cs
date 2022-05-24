using BackEnd_1.Interfaces;
using BackEnd_1.Services;

namespace BackEnd_1.Infra
{
    public class InjecaoDependencia
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddScoped<IProcessoCompraService, ProcessoCompraService>();
        }
    }
}
