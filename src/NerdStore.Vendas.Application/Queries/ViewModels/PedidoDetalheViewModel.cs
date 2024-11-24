using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Application.Queries.ViewModels
{
    public class PedidoDetalheViewModel
    {
        public int Codigo { get; set; }
        public Guid ClienteId { get; set; }
        public Guid? VoucherId { get; set; }
        public bool VoucherUtilizado { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCadastro { get; set; }
        public PedidoStatus PedidoStatus { get; set; }
        public IEnumerable<ItemPedidoViewModel> ItensPedido { get; set; }
        public string TipoPagamento { get; set; }
    }
}
