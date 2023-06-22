using IoC;

namespace Mc2.CrudTest.Presentation.API.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        NativeInjectorBootStrapper.RegisterServices(builder.Services);
    }
}

