using NGDictionary.Dto;
using System;
using System.Threading.Tasks;

namespace NGDictionary.Database.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);

        Task AddUserAsync(User user);

        void UpdateUser(User user);

        Task DeleteUserAsync(int userId);
    }
}
