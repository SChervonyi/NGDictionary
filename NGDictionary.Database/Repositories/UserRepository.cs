using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGDictionary.Database.Repositories
{
    public class UserRepository: IUserRepository
    {
        private EFDbContext _context;

        public UserRepository(EFDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _context.Users.Find(userId);
            _context.Users.Remove(userToDelete);
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(user => user.Username == username);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }
}
