namespace IntegrationTest.CustomerEndPints;

public class DeleteCustomer : ControllerTestsBase
{
    public DeleteCustomer(WebApiTesterFactory factory) : base(factory) { }

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
    public async Task test_DeleteCustomer_Success()
    {
        var customerApi = new CustomerAPI(BaseUrl, WebClient);

        var registreNewCustomerRes = await customerApi.RegisternewcustomerAsync(GetRegisterNewCustomerCommandViewModel());

        var customerViewModel = JsonConvert.DeserializeObject<CustomerViewModel>(
            JsonConvert.SerializeObject(registreNewCustomerRes.SucceedResult));
        var getdata = await customerApi.CustomerGETAsync(customerViewModel.Id);
        getdata.Should().NotBeNull();

        var removeCustomer= new DeleteCustomerCommandViewModel
        {
            Id = customerViewModel.Id
        };
        await customerApi.CustomerDELETEAsync(removeCustomer);
        try
        {
            await customerApi.CustomerGETAsync(customerViewModel.Id);
            Assert.Contains("(204)", "");
        }
        catch (Exception e)
        {
            Assert.Contains("(204)", e.Message);
        }
    }
}
