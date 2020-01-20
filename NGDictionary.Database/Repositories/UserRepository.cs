using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Repositories
{
    class UserRepository : BaseRepository<EFDbContext>, IUserRepository
    {
        public UserRepository(EFDbContext context)
            : base(context)
        {
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
