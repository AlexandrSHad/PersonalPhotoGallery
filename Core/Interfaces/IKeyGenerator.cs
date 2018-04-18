using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IKeyGenerator
    {
        string GetKay(string emailAddress);
    }
}
