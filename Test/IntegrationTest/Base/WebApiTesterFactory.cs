namespace IntegrationTest.Base;

public class WebApiTesterFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseContentRoot(".");
        builder.UseEnvironment("Development");
        builder
            .UseTestServer()
            .ConfigureTestServices(collection =>
            {
                collection.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                }).AddFakeJwtBearer();
            });
        base.ConfigureWebHost(builder);
    }
}
