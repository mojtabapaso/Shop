using MongoDB.Bson;

namespace Shop.Services.Contracts.MongoContracts;

public interface IMongoDbAuthenticationServices
{
    public Task<IEnumerable<BsonDocument>> GetAllAsync();
    public Task<BsonDocument> GetValueByKeyAsync(string Key, object Value);
    public Task DeleteAsync(string Key, object Value);
    public Task CreateAuthUserAsync(string phoneNumber, string Code);
    public Task<bool> AddTryAsync(string phoneNumber);

    public Task<BsonDocument> GetUserByPhoneNumberAsync(string PhoneNumber);
    public Task<bool> Deactivate(BsonDocument bsonElements);
	/// <summary>
	/// return true if phone number is valid 
	/// </summary>
	/// <param name="phoneNuber"></param>
	/// <returns></returns>
	public Task<bool> PhoneNumberIsValidAsync(string PhoneNumber);

}