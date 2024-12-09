namespace ThesisMate.Repositories
{
    public interface IFileRepository
    {
        string UploadFile(IFormFile file);
        void DeleteFile(string path);
    }
}