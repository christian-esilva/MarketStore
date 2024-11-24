using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediatr;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Pagamentos.Business;
using NerdStore.Vendas.Application.Queries;
using NerdStore.Vendas.Application.Queries.ViewModels;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class PedidoController(IPedidoQueries pedidoQueries, IPagamentoRepository pagamentoRepository, INotificationHandler<DomainNotification> notifications, IMediatrHandler mediatrHandler) 
        : ControllerBase(notifications, mediatrHandler)
    {
        [HttpGet("pedido")]
        public async Task<IActionResult> Index()
        {
            return View(await pedidoQueries.ObterPedidosCliente(ClienteId));
        }

        [HttpGet("pedido-detalhe/{id}")]
        public async Task<IActionResult> PedidoDetalhe(Guid id)
        {
            return View("PedidoDetalhe", await ObterPedidoDetalhe(id));
        }

        private async Task<PedidoDetalheViewModel> ObterPedidoDetalhe(Guid id)
        {
            var pedido = await pedidoQueries.ObterPedidoDetalhe(id);
            var formaPamento = await pagamentoRepository.ObterPorIdPedido(id);

            pedido.TipoPagamento = formaPamento.TipoPagamento;

            return pedido;
        }
    }
}
