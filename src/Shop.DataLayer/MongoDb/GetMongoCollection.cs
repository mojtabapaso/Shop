using MongoDB.Bson;
using MongoDB.Driver;

namespace Shop.DataLayer.context;

public class GetMongoCollection : IGetMongoCollection
{
	private static readonly MongoDatabase mongoDatabase = new MongoDatabase();
	private static readonly MongoCollection mongoCollection = new MongoCollection();

	public IMongoCollection<BsonDocument> GetUsersCollection()
	{
		var collection = mongoDatabase.CreateCollection("UserAuthentication", "User");
		return mongoCollection.CreateIndexWithExpirationInCollection(collection, TimeSpan.FromMinutes(3));
	}
	public IMongoCollection<BsonDocument> GetCouponCollection()
	{
		var collection = mongoDatabase.CreateCollection("UserCoupon", "Coupon");
		return mongoCollection.CreateIndexWithExpirationInCollection(collection, TimeSpan.FromDays(5));
	}
	public IMongoCollection<BsonDocument> GetCartCollection()
	{
		var collection = mongoDatabase.CreateCollection("UserCart", "Cart");
		return mongoCollection.CreateIndexWithExpirationInCollection(collection, TimeSpan.FromDays(7));
	}

}