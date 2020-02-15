using NGDictionary.Database.Entity;
using System;
using System.Threading.Tasks;

namespace NGDictionary.Services.Interfaces
{
    public interface IAuthService: IDisposable
    {
        Task<User> LoginAsync(string username, string password);

        Task AddUserAsync(User user);

        Task UpdatePasswordAsync(string username, string newPassword);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int userId);
    }
}
