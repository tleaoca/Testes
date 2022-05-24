using BackEnd_1.Models;

namespace BackEnd_1.Interfaces
{
    public interface IProcessoCompraService : IDisposable
    {
        Task<IEnumerable<Parcelas>> ObterParcelas(Compra compra);
    }
}
