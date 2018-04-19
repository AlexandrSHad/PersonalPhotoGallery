using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFileStorage
    {
        Task StoreFile(IFormFile file, string key);
    }
}
