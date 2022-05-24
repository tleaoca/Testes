using BackEnd_1.Interfaces;
using BackEnd_1.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BackEnd_1.Teste
{
    public class ProcessoCompraServiceTeste : IClassFixture<Inicializar>
    {

        private ServiceProvider provedorServico;

        public ProcessoCompraServiceTeste(Inicializar inicializar)
        {
            provedorServico = inicializar.ProvedorServico;
        }




        [Fact]
        public async Task DeveCalcularParcelasSemJuros()
        {
            using (var servico = provedorServico.GetService<IProcessoCompraService>())
            {
                Compra compra = new Compra { Produto = new Produto(), CondicaoPagamento = new CondicaoPagamento() };


                compra.Produto.Valor = 50000;
                compra.CondicaoPagamento.ValorEntrada = 5000;
                compra.CondicaoPagamento.QtdeParcelas = 2;

                var retorno = await servico.ObterParcelas(compra);

                Assert.True(retorno.Any(), "Erro ao calcular");
            }            
        }

        [Fact]
        public async Task DeveCalcularParcelasComJuros()
        {
            using (var servico = provedorServico.GetService<IProcessoCompraService>())
            {
                Compra compra = new Compra { Produto = new Produto(), CondicaoPagamento = new CondicaoPagamento() };


                compra.Produto.Valor = 50000;
                compra.CondicaoPagamento.ValorEntrada = 5000;
                compra.CondicaoPagamento.QtdeParcelas = 10;

                var retorno = await servico.ObterParcelas(compra);

                Assert.True(retorno.Any(), "Erro ao calcular");
            }
        }


    }
}