using MongoDB.Bson;

namespace Shop.Entities.MongoEntity;

public class CouponMongo : BaseMongoEntity
{
	public string UserId { get; set; }
	public string Code {  get; set; }
	public bool IsActive { get; set; }
	public int MinimumPurchaseAmount { get; set; }
	public int DiscountAmount { get; set; }
}
