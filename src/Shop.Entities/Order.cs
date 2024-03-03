namespace Shop.Entities;

public class Order:BaseEntitiy
{
	public User? User { get; set; }
	public bool IsPament { get; set; }
	public List<ItemCart>? ItemsCart { get; set; }
	public DateTime OrderDate { get; set; }= DateTime.Now;	
	public string TotalPrice { get; set; }
}
