
namespace NGDictionary.Database.Interfaces.Helpers
{
    public interface IUpdateEntityHelper<T>
    {
        void Update(T source, T target);
    }
}
