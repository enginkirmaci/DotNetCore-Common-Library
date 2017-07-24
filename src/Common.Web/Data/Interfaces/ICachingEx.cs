namespace Common.Web.Data
{
    public interface ICachingEx
    {
        void Add<T>(string key, T value, int? expireMinutes = null);

        void Remove(string key);

        bool Exists(string key);

        T Get<T>(string key);
    }
}