using Microsoft.EntityFrameworkCore;
using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGDictionary.Database.Repositories
{
    public class UserRepository: IUserRepository
    {
        private EFDbContext _context;

        public UserRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userToDelete = await _context.Users.FindAsync(userId);
            _context.Users.Remove(userToDelete);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.Username == username);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
