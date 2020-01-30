using NGDictionary.Dto;
using System;

namespace NGDictionary.Database.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User? GetUserByLogin(string login);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);
    }
}
