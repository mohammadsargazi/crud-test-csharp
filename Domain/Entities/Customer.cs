using Domain.Entities.Base;

namespace Domain.Entities;


public class Customer : BaseEntity
{
    #region Ctor
    public Customer(string firstname,
                   string lastname,
                   DateTimeOffset? dateOfBirth,
                   string phoneNumber,
                   string email,
                   string bankAccountNumber)
    {
        ID = Guid.NewGuid().ToString();
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;

    }
    #endregion

    #region Prop
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateTimeOffset? DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }
    #endregion

    #region HelperMethod
    public void UpdateFirstname(string firstname) => Firstname = firstname;
    public void UpdateLastname(string lastname) => Lastname = lastname;
    public void UpdateDateOfBirth(DateTimeOffset? dateOfBirth) => DateOfBirth = dateOfBirth;
    public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
    public void UpdateEmail(string email) => Email = email;
    public void UpdateBankAccountNumber(string bankAccountNumber) => BankAccountNumber = bankAccountNumber;
    #endregion
}

