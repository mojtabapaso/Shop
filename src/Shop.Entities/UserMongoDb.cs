using System.Text.Json;
using MongoDB.Bson;

namespace Shop.Entities;

public class UserMongoDb
{
	public string PhoneNumber { get; set; }
	public string Code { get; set; }
	public DateTime CreatedAt { get; set; }
	public int Try { get; set; }
	public bool IsValid { get; set; }

	public UserMongoDb()
	{
		PhoneNumber = string.Empty;
		Code = string.Empty;
		CreatedAt = DateTime.UtcNow;
		Try = 0;
		IsValid = true;
	}

	public UserMongoDb(string phoneNumber, string code)
	{
		PhoneNumber = phoneNumber;
		Code = code;
		CreatedAt = DateTime.UtcNow;
		Try = 0;
		IsValid = true;
	}
	public BsonDocument ToBsonDocument()
	{
		return new BsonDocument
	{
		{ "PhoneNumber", PhoneNumber },
		{ "Code", Code },
		{ "CreatedAt", CreatedAt },
		{ "Try", Try },
		{ "IsValid", IsValid }
	};
	}
}