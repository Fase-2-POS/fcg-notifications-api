namespace Fcg.Contracts;

public record PaymentProcessedEvent(
    int UserId,
    int GameId,
    decimal Price,
    string Status);
