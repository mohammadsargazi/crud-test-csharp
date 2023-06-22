using MassTransit;

namespace Mc2.CrudTest.Presentation.API.Configurations;

public static class MassTransitConfig
{
    public const string ApplicationName = "Customer";
    public static void AddMassTransitConfiguration(this WebApplicationBuilder builder)
    {

        string RabbitMQUserName = builder.Configuration.GetSection("RabbitMQ")["UserName"];
        string RabbitMQPassword = builder.Configuration.GetSection("RabbitMQ")["Password"];
        string RabbitMQAddress = builder.Configuration.GetSection("RabbitMQ")["Address"];


        builder.Services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri(RabbitMQAddress), h =>
                {
                    h.Username(RabbitMQUserName);
                    h.Password(RabbitMQPassword);
                });
            });
        });
    }
}