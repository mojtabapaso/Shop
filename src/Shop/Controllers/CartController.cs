﻿using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

public class CartController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
