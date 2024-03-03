using MongoDB.Bson;
using MongoDB.Driver;

namespace Shop.DataLayer.context;

public class MongoCollection
{
	public IMongoCollection<BsonDocument> CreateIndexWithExpirationInCollection(IMongoCollection<BsonDocument> mongoCollection, TimeSpan timeSpan)
	{
		var createIndexOptions = new CreateIndexOptions { ExpireAfter = timeSpan };
		mongoCollection.Indexes.CreateOne(new CreateIndexModel<BsonDocument>(Builders<BsonDocument>.IndexKeys.Ascending("CreatedAt"), createIndexOptions));

		return mongoCollection;
	}
}
