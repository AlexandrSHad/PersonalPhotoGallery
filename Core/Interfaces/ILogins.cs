using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ILogins
    {
        Task CreateUser(string email, string password);
        Task<User> GetUser(string email);
    }
}
