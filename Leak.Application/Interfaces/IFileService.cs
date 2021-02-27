using Microsoft.AspNetCore.Http;
using System.IO;

namespace Leak.Application.Interfaces
{
    public interface IFileService
    {
        public string CreateLocalFile(IFormFile formFile, string rootFolder);
        public bool UpdateLocalFile(IFormFile newFile, string existingFilePath);
        public bool DeleteLocalFile(string existingFilePath);
    }
}
