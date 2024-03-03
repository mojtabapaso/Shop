using MongoDB.Bson;

namespace Shop.Services.MongoContracts;

public interface IMongoCouponServices
{
	public Task<bool> CreateAsync(BsonDocument bsonElements, string userId);
	public Task<BsonDocument> FindAsync(string userId, string coupon);
	public Task<bool> ValidateCouponAsync(string userId, string coupon);

}
