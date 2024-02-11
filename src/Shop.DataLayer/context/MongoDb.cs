using MongoDB.Bson;
using MongoDB.Driver;

namespace Shop.DataLayer.context;

public static class MongoDb
{
	private static MongoClient dbClient = MongoDBContext.Context();

	private static IMongoCollection<BsonDocument> CreateIndexWithExpirationInCollection(IMongoDatabase mongoDatabase)
	{
		var usersCollection = mongoDatabase.GetCollection<BsonDocument>("Users");
		var createIndexOptions = new CreateIndexOptions { ExpireAfter = TimeSpan.FromMinutes(3) };
		usersCollection.Indexes.CreateOne(new CreateIndexModel<BsonDocument>(Builders<BsonDocument>.IndexKeys.Ascending("CreatedAt"), createIndexOptions));

		return usersCollection;
	}

	public static IMongoCollection<BsonDocument> GetUsersCollection()
	{
		IMongoDatabase db = dbClient.GetDatabase("UserAuthentication");
		return CreateIndexWithExpirationInCollection(db);

	}
	public static IMongoDatabase GetCartCollection()
	{
		IMongoDatabase db = dbClient.GetDatabase("UserCart");

		return db;
	}
}