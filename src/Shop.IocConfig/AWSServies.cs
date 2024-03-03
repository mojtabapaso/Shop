using Amazon.S3;
using Amazon.S3.Model;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.IocConfig;

public static class AWSServies
{
    public static IServiceCollection AddAWSServies(this IServiceCollection Services)
    {
        //Services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
        object value = Services.AddAWSService<IAmazonS3>();

        return Services;

    }
        public async static void Base()
    {
        Env.Load();
        //string accessKey = Env.GetString("LIARA_ACCESS_KEY");
        string accessKey = "ngcoeufpq9g5a011";
        //string secretKey = Env.GetString("LIARA_SECRET_KEY");
        string secretKey = "89604055-909d-4507-bc65-a047886c0fd8";
        //string bucketName = Env.GetString("LIARA_BUCKET_NAME");
        string bucketName = "tcp";
        //string endpoint = Env.GetString("LIARA_ENDPOINT");
        string endpoint = @"https://storage.iran.liara.space";


        //if (string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(endpoint))
        //{
        //    Console.WriteLine("Error: Missing required environment variables.");
        //    return;
        //}

        var config = new AmazonS3Config
        {
            ServiceURL = endpoint,
            ForcePathStyle = true,
            SignatureVersion = "4"
        };

        var credentials = new Amazon.Runtime.BasicAWSCredentials(accessKey, secretKey);
        using var client = new AmazonS3Client(credentials, config);

        //GetObjectRequest request = new GetObjectRequest
        //{
        //    BucketName = "tcp",
        //    Key = "key"
        //};

        ListObjectsV2Request request = new ListObjectsV2Request
        {
            BucketName = bucketName
        };
        ListObjectsV2Response response = await client.ListObjectsV2Async(request);

        //using (GetObjectResponse response = await client.GetObjectAsync(request))
        //{
        //    await response.WriteResponseStreamToFileAsync("destinationPath");
        //}

    }
    //public static async Task DownloadFile(string key, string destinationPath)
    //{

    //    GetObjectRequest request = new GetObjectRequest
    //    {
    //        BucketName = "sf",
    //        Key = key
    //    };

    //    using (GetObjectResponse response = await client.GetObjectAsync(request))
    //    {
    //        await response.WriteResponseStreamToFileAsync(destinationPath);
    //    }
    //}
    //public static async Task UploadFile(string key, string filePath)
    //{
    //    PutObjectRequest request = new PutObjectRequest
    //    {
    //        BucketName = "bucketName",
    //        Key = key,
    //        FilePath = filePath
    //    };

    //    await client.PutObjectAsync(request);
    //}


}
