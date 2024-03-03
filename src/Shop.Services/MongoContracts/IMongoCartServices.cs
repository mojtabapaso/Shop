using MongoDB.Bson;

namespace Shop.Services.Contracts.MongoContracts;

public interface IMongoCartServices
{
	public Task<BsonDocument> FindCartAsync(string id);
	public Task<bool> AddToCartAsync(BsonDocument bsonElements, string userId);
	public Task<bool> RemoveCartAsync(string userId);
	public Task<bool> RemoveItemFromCartAsync(string userId, string productId);
	public Task<bool> DecreaseCartItemQuantityAsync(string userId, string productId);
	public Task<(bool success, string message)> IncreaseCartItemQuantityAsync(string userId, string productId);
	public Task<IEnumerable<BsonDocument>> GetAllAsync();
}
