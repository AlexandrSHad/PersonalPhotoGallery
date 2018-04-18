using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class DefaultKeyGenerator : IKeyGenerator
    {
        public string GetKay(string emailAddress)
        {
            return emailAddress.Replace("@", string.Empty).Replace(".", string.Empty);
        }
    }
}
