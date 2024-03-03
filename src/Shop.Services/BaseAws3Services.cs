using Amazon.S3;
using Shop.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Amazon.S3.Model;

namespace Shop.Services;
public static class BaseAws3Services
{
    public async static Task<AmazonS3Client> ClientAsync()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        IConfigurationRoot root = builder.Build();
        IConfiguration Configuration;

        string awsAccessKeyId = root["AWS:AWSAccessKeyId"];
        string awsSecretAccessKey = root["AWS:AWSSecretAccessKey"];
        string bucketName = root["AWS:BucketName"];
        string endpoint = root["AWS:Endpoint"];

        var config = new AmazonS3Config
        {
            SignatureVersion = "2",
            AuthenticationRegion = "",
            ServiceURL = endpoint,
            ForcePathStyle = true,
        };

        var credentials = new Amazon.Runtime.BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey);
        var client = new AmazonS3Client(credentials, config);

        return client;
    }
}
public class Aws3Services : IAws3Services
{
    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var client = await BaseAws3Services.ClientAsync();

        var request = new PutObjectRequest();
        var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream);
        request.Key = "img/" + Guid.NewGuid().ToString();
        request.BucketName = "tcp";
        request.InputStream = memoryStream;
        request.ContentType = file.ContentType;

        await client.PutObjectAsync(request);
        string imageUrl = $"https://tcp.storage.iran.liara.space/{request.Key}";

        client.Dispose();
        return imageUrl;
    }
}