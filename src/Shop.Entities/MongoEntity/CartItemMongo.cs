namespace Shop.Entities.MongoEntity;

public class CartItemMongo
{
	public string ProductId { get; set; }
	public string ProductName { get; set; } // Added for convenience
	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public int QuantityValid { get; set; }

	//To keep the number of products in the main database 
	//and for check that the number of products in the shopping cart does not exceed that

}
