using System.ComponentModel;

namespace NerdStore.Vendas.Application.Queries.ViewModels
{
    public enum CarrinhoTipoPagamentoViewModel
    {
        [Description("Crédito")]
        Credito = 1,
        [Description("Débito")]
        Debito = 2,
        [Description("PIX")]
        Pix = 3
    }
}
