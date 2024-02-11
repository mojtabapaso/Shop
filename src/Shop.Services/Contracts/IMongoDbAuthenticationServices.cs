using MongoDB.Bson;

namespace Shop.Services.Contracts;

public interface IMongoDbAuthenticationServices
{
	public Task<IEnumerable<BsonDocument>> GetAllAsync();
	public Task<BsonDocument> GetValueByKeyAsync(string Key, object Value);
	public Task DeleteAsync(string Key, object Value);
	//public Task UpdateIntValueByKeyAsync(string Key, int Value, int newValue);
	//public Task UpdateStringValueByKeyAsync(string Key, string Value, string newValue);
	public Task CreateAuthUserAsync(string phoneNumber, string Code);
	public Task<bool> AddTryAsync(string phoneNumber);

	public Task<BsonDocument> GetUserByPhoneNumberAsync(string PhoneNumber);
	public Task<bool> Deactivate(BsonDocument bsonElements);
	public Task<bool> PhoneNumberIsValidAsync(string PhoneNumber);

}