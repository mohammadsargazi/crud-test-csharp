namespace Domain.Interfaces;

public interface IMessageBus
{
    Task Publish<T>(T sender, CancellationToken cancellationToken);
}
