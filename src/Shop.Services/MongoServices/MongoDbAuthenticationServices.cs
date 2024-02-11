using MongoDB.Bson;
using MongoDB.Driver;
using Shop.DataLayer.context;
using Shop.Entities;
using Shop.Services.Contracts;

namespace Shop.Services.MongoServices;

public class MongoDbAuthenticationServices : IMongoDbAuthenticationServices
{

    public async Task CreateAuthUserAsync(string phoneNumber, string Code)
    {
        var db = MongoDb.GetUsersCollection();
        var user = new UserMongoDb(phoneNumber, Code);
        await db.InsertOneAsync(user.ToBsonDocument());
    }
    public async Task<bool> AddTryAsync(string phoneNumber)
    {
        var db = MongoDb.GetUsersCollection();
        var doc = await GetUserByPhoneNumberAsync(phoneNumber);
        if (doc["Try"].AsInt32 <= 5)
        {
            await Deactivate(doc);
        }
        var update = Builders<BsonDocument>.Update.Set("Try", doc["Try"].AsInt32 + 1);
        await db.UpdateOneAsync(doc, update);
        return true;
    }
    public async Task<BsonDocument> GetUserByPhoneNumberAsync(string PhoneNumber)
    {
        var db = MongoDb.GetUsersCollection();
        var filter = Builders<BsonDocument>.Filter.Eq("PhoneNumber", PhoneNumber);
        var doc = await db.Find(filter).FirstOrDefaultAsync();
        return doc;
    }

    public async Task<BsonDocument> GetValueByKeyAsync(string Key, object Value)
    {
        var db = MongoDb.GetUsersCollection();
        var filter = Builders<BsonDocument>.Filter.Eq(Key, Value);
        var doc = await db.Find(filter).FirstOrDefaultAsync();
        return doc;
    }
    public async Task<IEnumerable<BsonDocument>> GetAllAsync()
    {
        var db = MongoDb.GetUsersCollection();
        var documents = await db.Find(new BsonDocument()).ToListAsync();
        return documents;
    }
    public async Task DeleteAsync(string Key, object Value)
    {
        var db = MongoDb.GetUsersCollection();
        var doc = await GetValueByKeyAsync(Key, Value);
        await db.DeleteOneAsync(doc);
    }

    public async Task<bool> Deactivate(BsonDocument bsonElements)
    {
        if (bsonElements is null)
        {
            return false;
        }
        var db = MongoDb.GetUsersCollection();
        var update = Builders<BsonDocument>.Update.Set("IsValid", false);
        await db.UpdateOneAsync(bsonElements, update);
        return true;
    }
    public async Task<bool> PhoneNumberIsValidAsync(string phoneNuber)
    {
        var user = await GetUserByPhoneNumberAsync(phoneNuber);
        if (user["IsValid"] == false)
        {
            return false;
        }
        if (user["Try"] <= 5)
        {
            return false;
        }
        if (user["CreateAt"] >= DateTime.UtcNow.AddMinutes(2))
        {
            return false;
        }
        return true;
    }
}