namespace Shop.Entities;

public class Address:BaseEntitiy
{
	public string Title { get; set; }
	public string Text { get; set; }
	public string PostalCode { get; set; }
	public string HouseNumber { get; set; }
	public string UserId { get; set; }
	public User User { get; set; }
	public Order? Order { get; set; }

}