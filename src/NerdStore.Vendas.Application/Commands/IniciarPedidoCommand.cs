using FluentValidation;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
    public class IniciarPedidoCommand(Guid pedidoId, Guid clienteId, decimal total, string tipoPagamento) : Command
    {
        public Guid PedidoId { get; private set; } = pedidoId;
        public Guid ClienteId { get; private set; } = clienteId;
        public decimal Total { get; private set; } = total;
        public string TipoPagamento { get; private set; } = tipoPagamento;

        public override bool EhValido()
        {
            ValidationResult = new IniciarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class IniciarPedidoValidation : AbstractValidator<IniciarPedidoCommand>
    {
        public IniciarPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido");

            RuleFor(c => c.TipoPagamento)
                .NotEmpty()
                .WithMessage("Tipo de pagamento inválido.");
        }
    }
}
