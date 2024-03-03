using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Shop.DataLayer.context;

public static class MongoDBContext
{
    private static readonly MongoClient _dbClient;

    static MongoDBContext()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        IConfigurationRoot root = builder.Build();
        string? mongoDbConnectionString = root["ConnectionStrings:DatabaseNoSQL:MongoDb"];
        _dbClient = new MongoClient(mongoDbConnectionString);
    }

    public static MongoClient Context()
    {
        return _dbClient;
    }
}
