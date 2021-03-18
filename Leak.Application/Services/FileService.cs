using Leak.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Leak.Application.Services
{
    public class FileService : IFileService
    {
        public string CreateLocalFile(IFormFile formFile, string rootFolder)
        {
            if (formFile == null)
                throw new ArgumentNullException(nameof(formFile));

            string fileExtension = Path.GetExtension(formFile.FileName);
            string fileName = Guid.NewGuid().ToString();
            string fullFileName = fileName + fileExtension;
            
            string destinationPath = Path.Combine(rootFolder, fullFileName);

            using(Stream stream = new FileStream(destinationPath, FileMode.CreateNew))
            {
                formFile.CopyTo(stream);
            }

            return destinationPath;
        }

        public bool DeleteLocalFile(string existingFilePath)
        {
            if (File.Exists(existingFilePath))
            {
                try
                {
                    File.Delete(existingFilePath);
                    return true;
                }
                catch (IOException) { }
            }

            return false;
        }

        public bool UpdateLocalFile(IFormFile newFile, string existingFilePath)
        {
            if (newFile == null)
                throw new ArgumentNullException(nameof(newFile));

            if (File.Exists(existingFilePath))
            {
                using(var existingFileStream = new FileStream(existingFilePath, FileMode.Truncate))
                {
                    newFile.CopyTo(existingFileStream);
                }

                return true;
            }

            return false;
        }
    }
}
