using MongoDB.Driver;

namespace Shop.DataLayer.context;

public static class MongoDb
{
	private static readonly MongoClient dbClient = MongoDBContext.Context();

	public static IMongoDatabase CreateDatabase(string nameDatabase)
	{
		var db = dbClient.GetDatabase(nameDatabase);
		return db;
	}
}
