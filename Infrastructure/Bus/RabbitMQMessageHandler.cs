using Domain.Interfaces;
using MassTransit;

namespace Bus;

public class RabbitMQMessageHandler : IMessageBus
{
    #region Fields
    private readonly IBus _bus;
    #endregion

    #region Ctor
    public RabbitMQMessageHandler(IBus bus)
    {
        _bus = bus;
    }
    #endregion

    public async Task Publish<T>(T sender, CancellationToken cancellationToken)
    {
        await _bus.Publish(sender, cancellationToken);
    }
}
