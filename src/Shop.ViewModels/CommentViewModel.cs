namespace Shop.ViewModels;

public class CommentViewModel:BaseViewModel
{
	public string Text { get; set; }
	//public string UserName { get; set; }
	//public string ProductName { get; set; }
	public string ProductId { get; set; }
	public bool IsPublished { get; set; }
	public bool IsSubComment { get; set; }
	public DateTime Created { get; set; }
	public List<CommentViewModel> SubComments { get; set; } = new List<CommentViewModel>();

}
