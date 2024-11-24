using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Pagamentos.Business;

namespace NerdStore.Pagamentos.Data.Repository
{
    public class PagamentoRepository(PagamentoContext context) : IPagamentoRepository
    {
        public IUnitOfWork UnitOfWork => context;


        public void Adicionar(Pagamento pagamento)
        {
            context.Pagamentos.Add(pagamento);
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            context.Transacoes.Add(transacao);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<Pagamento> ObterPorIdPedido(Guid idPedido)
        {
            return await context.Pagamentos.FirstOrDefaultAsync(x => x.PedidoId == idPedido);
        }
    }
}
