using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class LocalFileStorage : IFileStorage
    {
        public async Task StoreFile(IFormFile file, string key)
        {
            const string rootPath = "D:\\tmp\\PhotoStorage";
            var path = $"{rootPath}\\{key}";
            var fullFilePath = $"{path}\\{file.FileName}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var targetStream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(targetStream);
                targetStream.Close();
            }
        }
    }
}
