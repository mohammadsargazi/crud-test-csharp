namespace Domain.Commands.Validations;

public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidation()
    {
        ValidateId();
        ValidateFirstname();
        ValidateLastname();
        ValidatePhoneNumber();
        ValidateEmail();
    }
}

