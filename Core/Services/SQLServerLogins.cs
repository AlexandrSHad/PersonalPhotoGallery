using Core.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SQLServerLogins : ILogins
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<SQLServerLogins> _logger;

        public SQLServerLogins(DatabaseContext context, ILogger<SQLServerLogins> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateUser(string email, string password)
        {
            try
            {
                _context.Users.Add(new User {
                    Email = email,
                    Password = password
                });

                await _context.SaveChangesAsync();

                _logger.LogInformation($"A user with email address {email} was registered.");
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Error in CreateUser method.");
            }
        }

        public async Task<User> GetUser(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
