namespace Shop.Entities;

public class Comment : BaseEntitiy
{
	public string Text { get; set; }
	public virtual User User { get; set; }
	public virtual Product? Product { get; set; }
	public bool IsPublished { get; set; } = false;
	public bool IsSubCommnet { get; set; } = false;
	public DateTime Created { get; set; } = DateTime.Now;
	public virtual ICollection<Comment> SubComments { get; set; } = new List<Comment>();
}
