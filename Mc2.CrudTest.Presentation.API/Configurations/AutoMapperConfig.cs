using Application.Mapping;

namespace Mc2.CrudTest.Presentation.API.Configurations;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
    }
}