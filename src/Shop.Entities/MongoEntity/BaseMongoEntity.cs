using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shop.Entities.MongoEntity;

public class BaseMongoEntity
{
	[BsonIgnoreIfDefault]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }
	public DateTime CreatedAt { get; set; }

}
