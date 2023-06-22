using MongoDB.Entities;

namespace Mc2.CrudTest.Presentation.API.Configurations;

public static class MongoDbConfig
{
    public static void InitializeMongo(this WebApplicationBuilder builder)
    {
        string DatabaseName = builder.Configuration.GetSection("Database")["DatabaseName"];
        string DatabaseAddress = builder.Configuration.GetSection("Database")["DatabaseAddress"];
        string DatabasePort = builder.Configuration.GetSection("Database")["DatabasePort"];
        DB.InitAsync(DatabaseName, DatabaseAddress, int.Parse(DatabasePort));
    }
}
