namespace IntegrationTest.CustomerEndPints;

public class UpdateCustomer: ControllerTestsBase
{
    public UpdateCustomer(WebApiTesterFactory factory) : base(factory) { }

    #region HelperMethods
    private RegisterNewCustomerCommandViewModel GetRegisterNewCustomerCommandViewModel()
    {
        return new RegisterNewCustomerCommandViewModel
        {
            Firstname = Fixture.Create<string>(),
            Lastname = Fixture.Create<string>(),
            Email = Fixture.Create<string>() + "@example.com",
            DateOfBirth = Fixture.Create<DateTimeOffset>(),
            BankAccountNumber = Fixture.Create<string>(),
            PhoneNumber = "+31 (6) 12345678"
        };
    }
    #endregion

    [Fact]
    public async Task test_UpdateCustomer_Success()
    {
        var customerApi = new CustomerAPI(BaseUrl, WebClient);

        var registreNewCustomerRes = await customerApi.RegisternewcustomerAsync(GetRegisterNewCustomerCommandViewModel());

        var customerViewModel = JsonConvert.DeserializeObject<CustomerViewModel>(
            JsonConvert.SerializeObject(registreNewCustomerRes.SucceedResult));
        var getdata = await customerApi.CustomerGETAsync(customerViewModel.Id);
        getdata.Should().NotBeNull();

        var updateCustomer = new UpdateCustomerCommandViewModel
        {
            Id = customerViewModel.Id,
            Firstname = "UpdateValue",
            Lastname =customerViewModel.Lastname,
            BankAccountNumber=customerViewModel.BankAccountNumber,
            DateOfBirth=customerViewModel.DateOfBirth,
            Email= customerViewModel.Email,
            PhoneNumber= customerViewModel.PhoneNumber,
        };

        var resUpdate = await customerApi.CustomerPUTAsync(updateCustomer);
        var getUpdatedata = await customerApi.CustomerGETAsync(customerViewModel.Id);
        getUpdatedata.Firstname.Should().Match("UpdateValue");
    }
}
