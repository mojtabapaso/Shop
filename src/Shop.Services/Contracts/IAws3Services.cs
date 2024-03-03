using Microsoft.AspNetCore.Http;

namespace Shop.Services.Contracts;

public interface IAws3Services
{
    //public Task<byte[]> DownloadFileAsync(string file);

    public Task<string> UploadFileAsync(IFormFile file);

    //public Task<bool> DeleteFileAsync(string fileName, string versionId = "");
}

