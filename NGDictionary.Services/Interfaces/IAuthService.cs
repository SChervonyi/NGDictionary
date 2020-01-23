using NGDictionary.Dto;

namespace NGDictionary.Services.Interfaces
{
    public interface IAuthService
    {
        User GetUserByLogin(string login);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);
    }
}
