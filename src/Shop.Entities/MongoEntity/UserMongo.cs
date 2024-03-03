using System.Text.Json;
using MongoDB.Bson;

namespace Shop.Entities.MongoEntity;

public class UserMongo:BaseMongoEntity
{
	public string PhoneNumber { get; set; }
	public string Code { get; set; }
	public int Try { get; set; }
	public bool IsValid { get; set; }

	public UserMongo()
	{
		PhoneNumber = string.Empty;
		Code = string.Empty;
		CreatedAt = DateTime.UtcNow;
		Try = 0;
		IsValid = true;
	}

	public UserMongo(string phoneNumber, string code)
	{
		PhoneNumber = phoneNumber;
		Code = code;
		CreatedAt = DateTime.UtcNow;
		Try = 0;
		IsValid = true;
	}
	//public BsonDocument ToBsonDocument()
	//{
	//	return new BsonDocument
	//{
	//	{ "PhoneNumber", PhoneNumber },
	//	{ "Code", Code },
	//	{ "CreatedAt", CreatedAt },
	//	{ "Try", Try },
	//	{ "IsValid", IsValid }
	//};
	//}
}