using Microsoft.Extensions.Localization;
using MongoDB.Bson;
using MongoDB.Driver;
using Shop.DataLayer.context;
using Shop.Entities.MongoEntity;
using Shop.Services.Contracts.MongoContracts;

namespace Shop.Services.MongoServices;

public class MongoCartServices : IMongoCartServices
{
	private readonly IGetMongoCollection getMongoCollection;
	private readonly IStringLocalizer<MongoCartServices> localizer;

	public MongoCartServices(IGetMongoCollection getMongoCollection , IStringLocalizer<MongoCartServices> localizer)
	{
		this.getMongoCollection = getMongoCollection;
		this.localizer = localizer;
	}
	public async Task<bool> AddToCartAsync(BsonDocument bsonElements, string userId)
	{
		var db = getMongoCollection.GetCartCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);

		var doc = await db.Find(filter).FirstOrDefaultAsync();
		if (doc == null)
		{
			var shopCart = new ShoppingCartMongo
			{
				UserId = userId,
				CreatedAt = DateTime.UtcNow,
			};
			shopCart.Items.Add(bsonElements);
			await db.InsertOneAsync(shopCart.ToBsonDocument());
			return true;
		}
		var items = doc["Items"].AsBsonArray;

		for (int i = 0; i < items.Count; i++)
		{
			var item = items[i];
			if (item["ProductId"] == bsonElements["ProductId"])
			{
				var quantity = item["Quantity"];

				if (quantity == null)
				{
					return false;
				}
				var quantityItem = int.Parse(quantity.ToString());

				quantityItem++;
				item["Quantity"] = quantityItem;


				await db.ReplaceOneAsync(filter, doc);
				return true;
			}

		}
		items.Add(bsonElements);
		await db.ReplaceOneAsync(filter, doc);

		return true;
	}

	public async Task<bool> DecreaseCartItemQuantityAsync(string userId, string productId)
	{
		var db = getMongoCollection.GetCartCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);

		var doc = await db.Find(filter).FirstOrDefaultAsync();

		var items = doc["Items"].AsBsonArray;
		int indexToRemove = -1;

		for (int i = 0; i < items.Count; i++)
		{
			var item = items[i];
			if (item["ProductId"] == productId)
			{
				var quantity = item["Quantity"];

				if (quantity == null)
				{
					return false;
				}
				var quantityItem = int.Parse(quantity.ToString());

				if (quantity <= 1)
				{
					indexToRemove = i;
					break;
				}
				quantityItem--;
				item["Quantity"] = quantityItem;
			}
		}
		if (indexToRemove != -1)
		{
			items.RemoveAt(indexToRemove);
		}
		await db.ReplaceOneAsync(filter, doc);

		return true;
	}

	public async Task<BsonDocument> FindCartAsync(string userId)
	{
		var db = getMongoCollection.GetCartCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);

		var doc = await db.Find(filter).FirstOrDefaultAsync();
		return doc;
	}

	public Task<IEnumerable<BsonDocument>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<(bool success, string message)> IncreaseCartItemQuantityAsync(string userId, string productId)
	{
		var db = getMongoCollection.GetCartCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);

		var doc = await db.Find(filter).FirstOrDefaultAsync();

		var items = doc["Items"].AsBsonArray;
		foreach (var item in items)
		{
			if (item["ProductId"] == productId)
			{
				var quantity = item["Quantity"];
				if (quantity == null)
				{
					return (false, "InValid");
				}
				var quantityItem = int.Parse(quantity.ToString());
				if (item["QuantityValid"] <= quantityItem)
				{
					return (false, "Exceeds the number of valid products");
				}
				quantityItem++;
				item["Quantity"] = quantityItem;
			}
		}
		await db.ReplaceOneAsync(filter, doc);

		return (true, localizer["Mission accomplished"]);
	}

	public async Task<bool> RemoveCartAsync(string userId)
	{
		var db = getMongoCollection.GetCartCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);
		await db.DeleteOneAsync(filter);
		return true;
	}

	public async Task<bool> RemoveItemFromCartAsync(string userId, string productId)
	{
		var db = getMongoCollection.GetCartCollection();
		var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);

		var doc = await db.Find(filter).FirstOrDefaultAsync();

		var items = doc["Items"].AsBsonArray;
		var indexToRemove = -1;

		for (int i = 0; i < items.Count; i++)
		{
			var item = items[i];
			if (item["ProductId"] == productId)
			{
				indexToRemove = i;
				break;
			}
		}

		if (indexToRemove != -1)
		{
			items.RemoveAt(indexToRemove);
		}

		await db.ReplaceOneAsync(filter, doc);

		return true;
	}

}


