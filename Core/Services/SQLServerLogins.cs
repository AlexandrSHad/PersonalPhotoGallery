using Core.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SQLServerLogins : ILogins
    {
        private readonly DatabaseContext _context;

        public SQLServerLogins(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateUser(string email, string password)
        {
            _context.Users.Add(new User {
                Email = "test@gmail.com",
                Password = "123"
            });

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
