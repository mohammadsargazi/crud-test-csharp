using FluentAssertions;
using Newtonsoft.Json;

namespace IntegrationTest.CustomerEndPints;

public class RegisterNewCustomer: ControllerTestsBase
{
    public RegisterNewCustomer(WebApiTesterFactory factory) : base(factory) { }

    #region HelperMethods
    private RegisterNewCustomerCommandViewModel GetRegisterNewCustomerCommandViewModel()
    {
        return new RegisterNewCustomerCommandViewModel
        {
            Firstname = Fixture.Create<string>(),
            Lastname = Fixture.Create<string>(),
            Email = "email@example.com",
            DateOfBirth = Fixture.Create<DateTimeOffset>(),
            BankAccountNumber = Fixture.Create<string>(),
            PhoneNumber = "+1234567890"
        };
    }
    #endregion

    [Fact]
    public async Task test_RegisterNewCustomer_Success()
    {
        var customerApi = new CustomerAPI(BaseUrl, WebClient);
        
        var registreNewCustomerRes = await customerApi.RegisternewcustomerAsync(GetRegisterNewCustomerCommandViewModel());
        
        registreNewCustomerRes.Should().NotBeNull();
        
        var customerViewModel = JsonConvert.DeserializeObject<CustomerViewModel>(registreNewCustomerRes.SucceedResult.ToString());
        var getdata = await customerApi.CustomerGETAsync(customerViewModel.Id);
        getdata.Should().NotBeNull();
    }
}
