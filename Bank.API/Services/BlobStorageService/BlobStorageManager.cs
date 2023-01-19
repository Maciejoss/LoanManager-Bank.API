using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

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
        await blobClient.UploadAsync(fileContent, overwrite:true);
        await blobClient.SetHttpHeadersAsync(CreateBlobHeaders());
    }

    private BlobClient CreateBlob(int offerId)
    {
        var blobName = $"{offerId.ToString()}.pdf";
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
    
    public string GetDocument(int offerId)
    {
        var blob = CreateBlob(offerId);
        var builder = CreateSasToken(offerId);
        var uri = blob.GenerateSasUri(builder);

        return uri.ToString();
    }

    private BlobSasBuilder CreateSasToken(int offerId)
    {
        var sasBuilder = new BlobSasBuilder()
        {
            BlobContainerName = _blobContainerName,
            BlobName = offerId.ToString(),
            ExpiresOn = DateTime.UtcNow.AddMinutes(5),
        };

        sasBuilder.SetPermissions(BlobSasPermissions.Read);
        return sasBuilder;
    }
}