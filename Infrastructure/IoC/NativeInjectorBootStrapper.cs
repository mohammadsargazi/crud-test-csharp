using Bus;
using Data.Repository;
using Domain.Commands;
using Domain.Events;
using Domain.Interfaces;
using Domain.ResultModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        #region Application
        //services.AddScoped<ICustomerAppService, CustomerAppService>();
        #endregion

        #region Domain

        // Commands
        services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, Result>, RegisterNewCustomerCommand>();
        services.AddScoped<IRequestHandler<UpdateCustomerCommand, Result>, UpdateCustomerCommand>();
        services.AddScoped<IRequestHandler<DeleteCustomerCommand, Result>, DeleteCustomerCommand>();


        // Events 
        services.AddScoped<INotificationHandler<RegisteredNewCustomerEvent>, RegisteredNewCustomerEvent>();
        services.AddScoped<INotificationHandler<UpdatedCustomerEvent>, UpdatedCustomerEvent>();
        services.AddScoped<INotificationHandler<DeleteCustomerEvent>, DeleteCustomerEvent>();

        #endregion

        #region Infrastructure
        services.AddScoped<IMessageBus, RabbitMQMessageHandler>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        #endregion
    }
}
