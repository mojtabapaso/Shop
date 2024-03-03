using Microsoft.AspNetCore.Mvc;
using Shop.Entities;

namespace Shop.ViewModels;

public class DetailProductAndCommnetViewModel
{
	public Product product { get; set;}
	public CommentViewModel? comment { get; set;}
}
