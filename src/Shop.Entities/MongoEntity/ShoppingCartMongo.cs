using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop.Entities.MongoEntity;

public class ShoppingCartMongo
{
	[BsonIgnoreIfDefault]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }

	public string UserId { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	public List<BsonDocument> Items { get; set; } = new List<BsonDocument>();

}
