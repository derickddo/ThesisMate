using Humanizer;
using ThesisMate.Repositories;

namespace ThesisMate.Services
{
    public class FileService: IFileRepository
    {
        public string UploadFile(IFormFile file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "-" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var path = Path.Combine("wwwroot", "uploads", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            
            var dbPath = Path.Combine("uploads", fileName);

            return dbPath;
        }

        public void DeleteFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}