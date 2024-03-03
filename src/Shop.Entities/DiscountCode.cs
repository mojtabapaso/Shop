namespace Shop.Entities;

public class DiscountCode : BaseEntitiy
{
    public User? User { get; set; }
	public int Descount { get;set; }
	public DateTime Careate { get; set; } = DateTime.UtcNow;
	public DateTime Expired { get; set; } 
}