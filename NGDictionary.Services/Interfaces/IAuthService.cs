using NGDictionary.Dto;
using System;

namespace NGDictionary.Services.Interfaces
{
    public interface IAuthService: IDisposable
    {
        User Login(string login, string password);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);
    }
}
