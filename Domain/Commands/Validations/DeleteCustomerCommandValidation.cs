namespace Domain.Commands.Validations;
public class DeleteCustomerCommandValidation : CustomerValidation<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidation()
    {
        ValidateId();
    }
}
