using Leak.UI.MVC.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;

namespace Leak.UI.MVC.Utility
{
    public static class FolderFinder
    {
        public static string GetPostPhotosFolder([FromServices] IOptions<FilePathOption> filePathOptions, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            string photosFolder = filePathOptions.Value.PostPhotosFolder;
            string wwwRoot = webHostEnvironment.WebRootPath;

            return Path.Combine(wwwRoot, photosFolder);
        }
    }
}
