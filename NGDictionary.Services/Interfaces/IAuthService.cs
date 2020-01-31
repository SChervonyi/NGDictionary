using NGDictionary.Dto;

namespace NGDictionary.Services.Interfaces
{
    public interface IAuthService
    {
        User Login(string login, string password);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);
    }
}
