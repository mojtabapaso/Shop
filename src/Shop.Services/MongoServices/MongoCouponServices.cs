using MongoDB.Bson;
using MongoDB.Driver;
using Shop.Common.Generator;
using Shop.DataLayer.context;
using Shop.Entities.MongoEntity;
using Shop.Services.MongoContracts;

namespace Shop.Services.MongoServices;

public class MongoCouponServices : IMongoCouponServices
{
	private readonly IGetMongoCollection getMongoCollection;

	public MongoCouponServices(IGetMongoCollection getMongoCollection)
	{
		this.getMongoCollection = getMongoCollection;
	}
	public async Task<bool> CreateAsync(BsonDocument bsonElements, string userId)
	{
		var db = getMongoCollection.GetCouponCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);
		var doc = await db.Find(filter).FirstOrDefaultAsync();
		var coupon = new CouponMongo
		{
			UserId = userId,
			Code = GeneratorCoupon.DiscountCode(12),
			CreatedAt = DateTime.UtcNow,
			IsActive = true,
			MinimumPurchaseAmount = bsonElements["MinimumPurchaseAmount"].AsInt32,
			DiscountAmount = bsonElements["DiscountAmount"].AsInt32,
		};
		await db.InsertOneAsync(coupon.ToBsonDocument());
		return true;
	}
	public async Task<BsonDocument?> FindAsync(string userId,string coupon)
	{
		var db = getMongoCollection.GetCouponCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);
		var doc =  await db.Find(filter).ToListAsync();
		if(doc == null)
		{
			return null;
		}
		foreach(var item in doc)
		{
			if(item["Code"].AsString == coupon)
			{
				return item;
			}
		}
		return null;
	}
	public async Task<bool> ValidateCouponAsync(string userId, string coupon)
	{
		var couponBson = await FindAsync(userId, coupon);
        if (couponBson == null)
        {
			return false;
        }
        if (couponBson["IsActive"].AsBoolean == false)
		{
			return false;
		}
		return true;
	}
}
