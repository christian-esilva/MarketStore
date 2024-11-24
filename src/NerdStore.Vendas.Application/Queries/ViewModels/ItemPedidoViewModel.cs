namespace NerdStore.Vendas.Application.Queries.ViewModels
{
    public class ItemPedidoViewModel
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
