using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IKeyGenerator
    {
        string GetKey(string emailAddress);
    }
}
