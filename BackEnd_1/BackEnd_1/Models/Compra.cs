namespace BackEnd_1.Models
{
    public class Compra
    {
        public Compra(Produto produto, CondicaoPagamento condicaoPagamento)
        {
            Produto = produto;
            CondicaoPagamento = condicaoPagamento;
        }

        public Produto Produto { get; set; }
        public CondicaoPagamento CondicaoPagamento { get; set; }
    }
}
