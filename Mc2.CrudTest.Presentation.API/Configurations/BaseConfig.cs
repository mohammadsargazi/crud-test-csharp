using Bus.ConfigurationModel;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using System.Reflection;
using System.Text.Json.Serialization;
using MediatR;

namespace Mc2.CrudTest.Presentation.API.Configurations;

public static class BaseConfig
{
    public static void Configurations(this WebApplicationBuilder builder)
    {
        var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile($"appsettings.{env}.json", true);

        BsonSerializer.RegisterSerializer(DateTimeSerializer.LocalInstance);

        builder.Logging.ClearProviders();

        builder.Services.Configure<RabbitMQModel>(builder.Configuration.GetSection("RabbitMQ"));
        // MongoDB
        builder.InitializeMongo();

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.AddAutoMapperConfiguration();

        builder.AddSwaggerConfiguration();

        builder.AddDependencyInjectionConfiguration();


        builder.AddMassTransitConfiguration();

        builder.WebApplicationConfiguration();
    }

    public static void WebApplicationConfiguration(this WebApplicationBuilder builder)
    {
        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }


}