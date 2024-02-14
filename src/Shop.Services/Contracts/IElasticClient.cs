using Microsoft.EntityFrameworkCore;
using Nest;
using Shop.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

using ApiKey = Elastic.Transport.ApiKey;



namespace Shop.services.Contracts;

public interface IElasticClient
{
	public ISearchResponse<Product> Search(string query);
}
public class ElasticClient //: IElasticClient
{
	public void dd()
	{
		var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
	.CertificateFingerprint("<FINGERPRINT>")
	.Authentication(new BasicAuthentication("<USERNAME>", "<PASSWORD>"));
		var client = new ElasticsearchClient(settings);
	}

	//public ISearchResponse<Product> Search(string query)
	//{
	//	var client = new ElasticsearchClient("<CLOUD_ID>", new ApiKey("<API_KEY>"));

	//	return _client.Search<Product>(s => s
	//		.Query(q => q.Match(m => m.Name, query))
	//	);
	//}
	//public IQueryable<Product> Serarch(string query)
	//{
	//	var products = _context.Products.Where(p => p.Name.Contains(query));

	//	// جستجو در توضیحات محصول
	//	products = products.Where(p => p.Description.Contains(query));

	//	// جستجو در دسته بندی ها
	//	if (!string.IsNullOrEmpty(query))
	//	{
	//		var categories = _context.Categories.Where(c => c.Name.Contains(query));
	//		products = products.Where(p => categories.Any(c => c.Id == p.CategoryId));
	//	}

	//	// بازگشت نتایج
	//	return products;
	//}
}