using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPhotoMetaData
    {
        Task SavePhotoMetaData(string userName, string descriptions, string fileName);
    }
}
