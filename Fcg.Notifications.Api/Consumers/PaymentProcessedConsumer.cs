using Fcg.Contracts;
using MassTransit;

namespace Fcg.Notifications.Api.Consumers;

public class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
{
    private readonly ILogger<PaymentProcessedConsumer> _logger;

    public PaymentProcessedConsumer(ILogger<PaymentProcessedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        var pagamento = context.Message;

        if (pagamento.Status != "Approved")
        {
            return Task.CompletedTask;
        }

        _logger.LogInformation(
            "E-mail de confirmação de compra enviado para o usuário {UserId}. Jogo: {GameId} | Valor: {Price}",
            pagamento.UserId,
            pagamento.GameId,
            pagamento.Price);

        return Task.CompletedTask;
    }
}
