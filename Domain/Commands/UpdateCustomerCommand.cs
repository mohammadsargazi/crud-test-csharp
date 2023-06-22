namespace Domain.Commands;

public class UpdateCustomerCommand : BaseCustomerCommand
        , IRequestHandler<UpdateCustomerCommand, Result>
{
    #region Fields
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Ctor
    public UpdateCustomerCommand(ICustomerRepository customerRepository, IMediator mediator)
    {
        _customerRepository = customerRepository;
        _mediator = mediator;
    }
    #endregion

    #region Validate
    public bool IsValid()
    {
        ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
    #endregion

    #region Handler
    public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

        var customer = await _customerRepository.GetById(request.Id, cancellationToken);

        if (customer == null)
        {
            request.AddErrorToValidationResult("Customer not found", "Customer not found");
            return new Result { FailedResults = request.ValidationResult };
        }

        var isDuplicateCustomer = await _customerRepository.IsDuplicateCustomer(customer);
        if (isDuplicateCustomer)
        {
            request.AddErrorToValidationResult("Duplicated customer", "There is another customer with this information");
            return new Result { FailedResults = request.ValidationResult };
        }

        customer.UpdateFirstname(request.Firstname);
        customer.UpdateLastname(request.Lastname);
        customer.UpdateEmail(request.Email);
        customer.UpdateDateOfBirth(request.DateOfBirth);
        customer.UpdatePhoneNumber(request.PhoneNumber);
        customer.UpdateBankAccountNumber(request.BankAccountNumber);
        

        var result = await _customerRepository.UpdateAsync(customer, cancellationToken);

        await _mediator.Publish(new UpdatedCustomerEvent(customer));

        return new Result { SucceedResult = customer };
    }
    #endregion
}
