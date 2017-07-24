using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Common.Web.Data
{
    public class SessionEx : ISessionEx
    {
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionEx(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set<T>(string key, T value)
        {
            _session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public void Remove(string key)
        {
            _session.Remove(key);
        }

        public bool Exists(string key)
        {
            return _session.Get(key) != null;
        }

        public T Get<T>(string key)
        {
            var value = _session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public string Get(string key)
        {
            return _session.GetString(key);
        }
    }
}