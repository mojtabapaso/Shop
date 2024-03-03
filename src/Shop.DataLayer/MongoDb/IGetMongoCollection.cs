using MongoDB.Bson;
using MongoDB.Driver;

namespace Shop.DataLayer.context;

public interface IGetMongoCollection
{
	public IMongoCollection<BsonDocument> GetUsersCollection();
	public IMongoCollection<BsonDocument> GetCartCollection();
	public IMongoCollection<BsonDocument> GetCouponCollection();
}
