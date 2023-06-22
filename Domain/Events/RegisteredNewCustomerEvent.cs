namespace Domain.Events;

public class RegisteredNewCustomerEvent : INotification,
    INotificationHandler<RegisteredNewCustomerEvent>
{
    #region Fileds
    private readonly IMessageBus _messagebus;
    #endregion

    #region Props
    public Customer Customer { get; private set; }
    #endregion

    #region Ctor
    public RegisteredNewCustomerEvent(Customer customer)
    {
        Customer = customer;
    }

    public RegisteredNewCustomerEvent(IMessageBus messageBus)
    {
        _messagebus = messageBus;
    }
    #endregion

    #region Handler
    public Task Handle(RegisteredNewCustomerEvent sender, CancellationToken cancellationToken)
    {
        _messagebus.Publish(sender, cancellationToken);
        return Task.CompletedTask;
    }
    #endregion
}