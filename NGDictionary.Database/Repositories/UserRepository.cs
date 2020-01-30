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
        private EFDbContext context;

        public UserRepository(EFDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = context.Users.Find(userId);
            context.Users.Remove(userToDelete);
        }

        public User GetUserByLogin(string login)
        {
            return context.Users.SingleOrDefault(user => user.Login == login);
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }
    }
}
