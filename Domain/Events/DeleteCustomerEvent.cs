namespace Domain.Events;

public class DeleteCustomerEvent : INotification,
    INotificationHandler<DeleteCustomerEvent>
{
    #region Fileds
    private readonly IMessageBus _messagebus;
    #endregion

    #region Props
    public Customer Customer { get; private set; }
    #endregion

    #region Ctor
    public DeleteCustomerEvent(Customer customer)
    {
        Customer = customer;
    }

    public DeleteCustomerEvent(IMessageBus messageBus)
    {
        _messagebus = messageBus;
    }
    #endregion

    #region Handler
    public Task Handle(DeleteCustomerEvent sender, CancellationToken cancellationToken)
    {
        _messagebus.Publish(sender, cancellationToken);
        return Task.CompletedTask;
    }
    #endregion
}