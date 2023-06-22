namespace Domain.Events;

public class UpdatedCustomerEvent : INotification,
    INotificationHandler<UpdatedCustomerEvent>
{
    #region Fileds
    private readonly IMessageBus _messagebus;
    #endregion

    #region Props
    public Customer Customer { get; private set; }
    #endregion

    #region Ctor
    public UpdatedCustomerEvent(Customer customer)
    {
        Customer = customer;
    }

    public UpdatedCustomerEvent(IMessageBus messageBus)
    {
        _messagebus = messageBus;
    }
    #endregion

    #region Handler
    public Task Handle(UpdatedCustomerEvent sender, CancellationToken cancellationToken)
    {
        _messagebus.Publish(sender, cancellationToken);
        return Task.CompletedTask;
    }
    #endregion
}
