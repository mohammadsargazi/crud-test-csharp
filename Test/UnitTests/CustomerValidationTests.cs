using Domain.Commands;
using Domain.Commands.Validations;

namespace UnitTests;

public class CustomerValidationTests
{
    private CustomerValidation<BaseCustomerCommand> validator;

    public CustomerValidationTests()
    {
        // Initialize your validator here (if required)
        validator = new CustomerValidation<BaseCustomerCommand>();
    }

    [Theory]
    [InlineData("+989121234567", true)]
    [InlineData("+982188776655", false)]
    [InlineData("+16156381234", false)]
    public void BeValidMobileNumber_ValidNumber_ReturnsTrue(string phoneNumber, bool expected)
    {
        var reult = validator.BeValidMobileNumber(phoneNumber);

        Assert.Equal(reult, expected);
    }
}

