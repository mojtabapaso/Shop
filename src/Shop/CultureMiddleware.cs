namespace Shop;

public class CultureMiddleware
{
	private readonly RequestDelegate _next;
	public CultureMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task InvokeAsync(HttpContext context)
	{
		var cultureFromQuery = context.Request.Query["culture"];
		if (string.IsNullOrEmpty(cultureFromQuery))
		{
			cultureFromQuery = "fa";
		}

		var cookieOptions = new CookieOptions
		{
			Expires = DateTimeOffset.UtcNow.AddDays(30),
			SameSite = SameSiteMode.Strict
		};
		context.Response.Cookies.Append("culture", cultureFromQuery, cookieOptions);


		object value = context.Response.Headers.Remove("Content-Language");
		context.Response.Headers.Add("Content-Language", cultureFromQuery);
		var rr = context.Response.Headers.ToList();

		await _next(context);
	}
}