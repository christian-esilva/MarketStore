using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediatr;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("3CF0AAD3-4883-45FD-962E-5CB38C50B913");

        private readonly IMediatrHandler _mediatrHandler;
        private readonly DomainNotificationHandler _notifications;

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, IMediatrHandler mediatrHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatrHandler = mediatrHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }
        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatrHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }
}
