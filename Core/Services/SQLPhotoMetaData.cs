using Core.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SQLPhotoMetaData : IPhotoMetaData
    {
        private readonly DatabaseContext _context;

        public SQLPhotoMetaData(DatabaseContext context)
        {
            _context = context;
        }

        public async Task SavePhotoMetaData(string userName, string descriptions, string fileName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userName);

            if (user != null)
            {
                var photo = new Photos
                {
                    User = user,
                    Description = descriptions,
                    FileName = fileName
                };
                _context.Photos.Add(photo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
