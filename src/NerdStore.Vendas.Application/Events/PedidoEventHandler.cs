﻿using MediatR;
using NerdStore.Core.Communication.Mediatr;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoEventHandler :
        INotificationHandler<PedidoRascunhoIniciadoEvent>,
        INotificationHandler<PedidoAtualizadoEvent>,
        INotificationHandler<PedidoItemAdicionadoEvent>,
        INotificationHandler<PedidoEstoqueRejeitadoEvent>,
        INotificationHandler<PedidoPagamentoRealizadoEvent>,
        INotificationHandler<PedidoPagamentoRecusadoEvent>

    {
        private readonly IMediatrHandler _mediatrHandler;

        public PedidoEventHandler(IMediatrHandler mediatorHandler)
        {
            _mediatrHandler = mediatorHandler;
        }

        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task Handle(PedidoEstoqueRejeitadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarComando(new CancelarProcessamentoPedidoCommand(notification.PedidoId, notification.ClienteId));
        }

        public async Task Handle(PedidoPagamentoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarComando(new FinalizarPedidoCommand(notification.PedidoId, notification.ClienteId));
        }

        public async Task Handle(PedidoPagamentoRecusadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatrHandler.EnviarComando(new CancelarProcessamentoPedidoEstornarEstoqueCommand(notification.PedidoId, notification.ClienteId));
        }

    }
}
