using NerdStore.Pagamentos.Business;

namespace NerdStore.Pagamentos.AntiCorruption
{
    public class PagamentoCartaoCreditoFacade(IPayPalGateway payPalGateway, IConfigurationManagerr configManager) : IPagamentoCartaoCreditoFacade
    {
        public Transacao RealizarPagamento(Pedido pedido, Pagamento pagamento)
        {
            var apiKey = configManager.GetValue("apiKey");
            var encriptionKey = configManager.GetValue("encriptionKey");

            var serviceKey = payPalGateway.GetPayPalServiceKey(apiKey, encriptionKey);

            var pagamentoResult = payPalGateway.CommitTransaction(pedido.Id.ToString(), pagamento.Valor);

            // TODO: O gateway de pagamentos que deve retornar o objeto transação
            var transacao = new Transacao
            {
                PedidoId = pedido.Id,
                Total = pedido.Valor,
                PagamentoId = pagamento.Id
            };

            if (pagamentoResult)
            {
                transacao.StatusTransacao = StatusTransacao.Pago;
                return transacao;
            }

            transacao.StatusTransacao = StatusTransacao.Recusado;
            return transacao;
        }
    }
}