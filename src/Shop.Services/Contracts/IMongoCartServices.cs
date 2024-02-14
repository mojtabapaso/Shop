using MongoDB.Bson;

namespace Shop.services.Contracts;

public interface IMongoCartServices
{
	public Task AddToCart(BsonDocument bsonElements);
	//public Task ChangeCartBy
}
