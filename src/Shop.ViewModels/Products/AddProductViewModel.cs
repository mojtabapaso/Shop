using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels.Products;

public  class AddProductViewModel
{
	[Required(ErrorMessage = "عنوان را وارد کنید")]

	public string Title { get; set;}

	[Required (ErrorMessage = "توضیحات را وارد کنید ")]
	 
	public string Description { get; set;}

	//[Required(ErrorMessage = "Please enter price")]
	//public int Price { get; set; }

}
