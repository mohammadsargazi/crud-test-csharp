namespace Domain.Commands.Validations;

public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
{
    public RegisterNewCustomerCommandValidation()
    {
        ValidateFirstname();
        ValidateLastname();
        ValidatePhoneNumber();
        ValidateEmail();
    }
}
