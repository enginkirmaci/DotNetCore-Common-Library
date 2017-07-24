namespace Common.Web.Data
{
    public interface ISessionEx
    {
        void Set<T>(string key, T value);

        void Remove(string key);

        bool Exists(string key);

        T Get<T>(string key);

        string Get(string key);
    }
}