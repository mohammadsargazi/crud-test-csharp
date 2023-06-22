namespace Domain.Commands;

public class RegisterNewCustomerCommand : BaseCustomerCommand
        , IRequestHandler<RegisterNewCustomerCommand, Result>
{
    #region Fields
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Ctor
    public RegisterNewCustomerCommand(ICustomerRepository customerRepository, IMediator mediator)
    {
        _customerRepository = customerRepository;
        _mediator = mediator;
    }
    #endregion

    #region Validate
    public bool IsValid()
    {
        ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
    #endregion

    #region Handler
    public async Task<Result> Handle(RegisterNewCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return new Result() { FailedResults = request.ValidationResult };

        var emailExists = await _customerRepository.IsExistEmail(request.Email);
        if (emailExists)
        {
            request.AddErrorToValidationResult("Duplicated email", "There is another customer with this email");
            return new Result { FailedResults = request.ValidationResult };
        }

        var dataExists = await _customerRepository.CheckDataExistence(request.Firstname, request.Lastname, request.DateOfBirth);
        if (dataExists)
        {
            request.AddErrorToValidationResult("Duplicated data", "There is another customer with this information");
            return new Result { FailedResults = request.ValidationResult };
        }

        var newCustomer = new Customer(request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);
        var result = await _customerRepository.InsertAsync(newCustomer, cancellationToken);

        await _mediator.Publish(new RegisteredNewCustomerEvent(newCustomer));

        return new Result { SucceedResult = result };
    }
    #endregion
}
