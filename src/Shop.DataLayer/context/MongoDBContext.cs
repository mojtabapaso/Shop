using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Shop.DataLayer.context;

public static class MongoDBContext
{
	public static MongoClient Context()
	{
		IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
		IConfigurationRoot root = builder.Build();
		string? mongoDbConnectionString = root["ConnectionStrings:DatabaseNoSQL:MongoDb"];
		MongoClient dbClient = new MongoClient(mongoDbConnectionString);
		return dbClient;
	}

}