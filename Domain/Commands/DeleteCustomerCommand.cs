namespace Domain.Commands;

public class DeleteCustomerCommand : BaseCustomerCommand
        , IRequestHandler<DeleteCustomerCommand, Result>
{
    #region Fields
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Ctor
    public DeleteCustomerCommand()
    {
            
    }
    public DeleteCustomerCommand(ICustomerRepository customerRepository, IMediator mediator)
    {
        _customerRepository = customerRepository;
        _mediator = mediator;
    }
    #endregion

    #region Validate
    public bool IsValid()
    {
        ValidationResult = new DeleteCustomerCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
    #endregion

    #region Handler
    public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

        var customer = await _customerRepository.GetById(request.Id, cancellationToken);

        if (customer == null)
        {
            request.AddErrorToValidationResult("Customer not found", "Customer not found");
            return new Result { FailedResults = request.ValidationResult };
        }

        var result = await _customerRepository.DeleteAsync(customer, cancellationToken);

        await _mediator.Publish(new DeleteCustomerEvent(customer));

        return new Result { SucceedResult = customer };

    }
    #endregion
}
