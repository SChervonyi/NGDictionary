using NGDictionary.Dto;
using System;

namespace NGDictionary.Database.Interfaces.Repositories
{
    interface IUserRepository : IDisposable
    {
        User GetUserByLogin(string login);

        void AddUser(User user);

        void UpdateUser(int userId);

        void DeleteUser(int userId);
    }
}
