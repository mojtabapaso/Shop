using MongoDB.Bson;
using MongoDB.Driver;

namespace Shop.DataLayer.context;

public class MongoDatabase
{
	public IMongoCollection<BsonDocument> CreateCollection(string nameDatabase, string nameCollection)
	{

		var db = MongoDb.CreateDatabase(nameDatabase);
		var collection = db.GetCollection<BsonDocument>(nameCollection);
		return collection;
	}
}
