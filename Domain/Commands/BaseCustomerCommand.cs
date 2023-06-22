using Domain.ResultModel;
using FluentValidation.Results;
using MediatR;

namespace Domain.Commands;

public class BaseCustomerCommand : IRequest<Result>
{
    public Guid ID { get; protected set; }
    public string Firstname { get; protected set; }
    public string Lastname { get; protected set; }
    public DateTimeOffset? DateOfBirth { get; protected set; }
    public string PhoneNumber { get; protected set; }
    public string Email { get; protected set; }
    public string BankAccountNumber { get; protected set; }
    public ValidationResult ValidationResult { get; protected set; }
}
