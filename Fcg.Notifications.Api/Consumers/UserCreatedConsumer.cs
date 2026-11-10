using Fcg.Contracts;
using MassTransit;

namespace Fcg.Notifications.Api.Consumers;

public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedConsumer> _logger;

    public UserCreatedConsumer(ILogger<UserCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var usuario = context.Message;

        _logger.LogInformation(
            "E-mail de boas-vindas enviado para {Email}. Mensagem: Olá {Nome}, seja bem-vindo(a) à FIAP Cloud Games!",
            usuario.Email,
            usuario.Nome);

        return Task.CompletedTask;
    }
}
