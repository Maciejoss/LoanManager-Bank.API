using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Bank.API.Services.BlobStorageService;

public class BlobStorageManager
{
    private string _connectionString;
    private readonly string _blobContainerName = "documents";

    public BlobStorageManager(IConfiguration configuration)
    {
        _connectionString = configuration.GetSection("StorageConnection").GetValue<string>("DefaultConnection");
    }

    public async Task Upload(int offerId, Stream fileContent)
    {
        var blobClient = CreateBlob(offerId);
        await blobClient.UploadAsync(fileContent);
        await blobClient.SetHttpHeadersAsync(CreateBlobHeaders());
    }

    private BlobClient CreateBlob(int offerId)
    {
        var blobName = offerId.ToString();
        var container = new BlobContainerClient(_connectionString, _blobContainerName);
        container.CreateIfNotExistsAsync();
        return container.GetBlobClient(blobName);
    }

    private BlobHttpHeaders CreateBlobHeaders()
    {
       return new BlobHttpHeaders()
        {
            ContentType = "application/pdf",
        };
    }
    
    public async Task<Stream> Download(int offerId)
    {
        var blob = CreateBlob(offerId);
        var blobContent = new MemoryStream();
        await blob.DownloadToAsync(blobContent);
        blobContent.Position = 0;
        return blobContent;
    }
}