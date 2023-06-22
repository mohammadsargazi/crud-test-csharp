namespace IntegrationTest.Base
{
    public class ControllerTestsBase : IClassFixture<WebApiTesterFactory>
    {
        protected readonly WebApiTesterFactory Factory;
        protected readonly HttpClient WebClient;
        protected readonly dynamic CourierToken;
        protected readonly dynamic AdminToken;
        protected readonly Fixture Fixture;
        protected readonly string VersionHeader = "v1";

        protected string BaseUrl { get; }

        public ControllerTestsBase(WebApiTesterFactory factory)
        {
            Factory = factory;
            WebClient = factory.CreateClient();
            WebClient.DefaultRequestHeaders.Add("App-Version", "something test");

            BaseUrl = "http://localhost:51361/"; 
            Fixture = new Fixture();
        }
    }
}
