using BackEnd_1.Interfaces;
using BackEnd_1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BackEnd_1.Services
{
    public class ProcessoCompraService : IProcessoCompraService
    {        
        public async Task<IEnumerable<Parcelas>> ObterParcelas(Compra compra)
        {            
            var listaParcelas = new List<Parcelas>();

            //var x = PegarTaxaSelic();

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



        // Tentando descobrir o motivo de ele não ta lendo a chamada no formato JSON. No momento ele ta trazendo como text, quebrando na hora do Deserialize. 
        private async Task<List<TaxaSelic>> PegarTaxaSelic()
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var url = new Uri("https://api.bcb.gov.br/dados/serie/bcdata.sgs.11/dados/ultimos/10?formato=json");
                    

                    http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    http.DefaultRequestHeaders.Add("MediaType", "application/json");

                    var result = http.GetAsync(url).GetAwaiter().GetResult();

                    
                    var teste = JsonConvert.DeserializeObject<List<TaxaSelic>>(result.ToString());
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void Dispose()
        {
           
        }
    }
}
