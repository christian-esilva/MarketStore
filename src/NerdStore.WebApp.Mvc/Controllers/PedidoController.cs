using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediatr;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Queries;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class PedidoController(IPedidoQueries pedidoQueries, INotificationHandler<DomainNotification> notifications, IMediatrHandler mediatrHandler) 
        : ControllerBase(notifications, mediatrHandler)
    {
        [HttpGet("pedido")]
        public async Task<IActionResult> Index()
        {
            return View(await pedidoQueries.ObterPedidosCliente(ClienteId));
        }
    }
}
