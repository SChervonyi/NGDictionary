using NGDictionary.Database.Interfaces.Helpers;
using NGDictionary.Dto;

namespace NGDictionary.Database.Helpers
{
    public class UserUpdateHelper: IUpdateEntityHelper<User>
    {
        // It could be an extension method for User, but it's better to avoid adding a logic to a model.
        public void Update(User source, User target)
        {
            target.Email = source.Email;
            target.Login = source.Login;
            target.Password = source.Password;
        }
    }
}
