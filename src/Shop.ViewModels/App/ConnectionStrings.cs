using Newtonsoft.Json;

namespace Shop.ViewModels.App;

//public class ConnectionStrings
//{
//    public string? ShopDbContextConnection { get; set; }
//}
public class DatabaseSQL
{
	public string ShopDbContextConnection { get; set; }
}

public class DatabaseNoSQL
{
	public string MongoDb { get; set; }
}

public class ConnectionStrings
{
	public DatabaseSQL DatabaseSQL { get; set; }
	public DatabaseNoSQL DatabaseNoSQL { get; set; }
}

