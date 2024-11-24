namespace NerdStore.Core.DomainObjects.DTO
{
    public class PagamentoPedido
    {
        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal Total { get; set; }
        public string TipoPagamento { get; set; }
    }
}