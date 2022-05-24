using BackEnd_1.Interfaces;
using BackEnd_1.Models;

namespace BackEnd_1.Services
{
    public class ProcessoCompraService : IProcessoCompraService
    {
        public async Task<IEnumerable<Parcelas>> ObterParcelas(Compra compra)
        {
            
            var listaParcelas = new List<Parcelas>();

            var numeroParcelas = compra.CondicaoPagamento.QtdeParcelas;
            var contador = 0;
            var taxaSelic = 0.015;
            var saldoParcelar = compra.Produto.Valor - compra.CondicaoPagamento.ValorEntrada;
            var saldoComJuros = (saldoParcelar * taxaSelic) + saldoParcelar;

            while (contador < numeroParcelas)
            {
                Parcelas parcelas = new Parcelas();

                parcelas.NumeroParcela = contador + 1;
                
                parcelas.TaxaJurosAoMes = numeroParcelas >= 6 ? (saldoParcelar * taxaSelic) / numeroParcelas : 0;

                parcelas.Valor = (parcelas.TaxaJurosAoMes != 0 ? saldoComJuros / numeroParcelas : saldoParcelar / numeroParcelas);

                listaParcelas.Add(parcelas);

                contador++;
            }
            
            return await Task.FromResult(listaParcelas);
        }

        public void Dispose()
        {
           
        }
    }
}
