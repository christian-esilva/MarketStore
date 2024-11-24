using NerdStore.Core.DomainObjects;

namespace NerdStore.Pagamentos.Business
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public Guid PedidoId { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public string TipoPagamento { get; set; }

        // EF. Rel.
        public Transacao Transacao { get; set; }

        public void AtualizarStatusPagamento(string status)
        {
            Status = status;
        }
    }
}