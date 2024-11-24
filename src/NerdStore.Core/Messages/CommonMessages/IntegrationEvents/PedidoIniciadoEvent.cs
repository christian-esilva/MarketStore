using NerdStore.Core.DomainObjects.DTO;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoIniciadoEvent(Guid pedidoId, Guid clienteId, ListaProdutosPedido produtosPedido, decimal total, string tipoPagamento) : IntegrationEvent
    {
        public Guid PedidoId { get; private set; } = pedidoId;
        public Guid ClienteId { get; private set; } = clienteId;
        public decimal Total { get; private set; } = total;
        public string TipoPagamento { get; set; } = tipoPagamento;
        public ListaProdutosPedido ProdutosPedido { get; private set; } = produtosPedido;
    }
}
