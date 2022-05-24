using BackEnd_1.Interfaces;
using BackEnd_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_1.Controllers
{
    
    [ApiController]
    public class ProcessoCompraController : ControllerBase
    {
        private readonly IProcessoCompraService servicoCompra;

        public ProcessoCompraController(IProcessoCompraService servicoCompra)
        {
            this.servicoCompra = servicoCompra;
        }

        [HttpGet]
        [Route("compra-parcelado")]
        public async Task<IEnumerable<Parcelas>> CompraParcelado([FromQuery] Compra compra)
        {
            var resposta = await servicoCompra.ObterParcelas(compra);

            return resposta;
        }
    }
}
