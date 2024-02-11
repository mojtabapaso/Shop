using MongoDB.Bson;

namespace Shop.Services.Contracts;

public interface IMongoCartServices
{
	public Task AddToCart(BsonDocument bsonElements);
	//public Task ChangeCartBy
}
