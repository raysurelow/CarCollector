namespace CarCollector.Services.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
    }
}
