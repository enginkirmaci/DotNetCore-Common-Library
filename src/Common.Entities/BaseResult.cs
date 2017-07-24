using Newtonsoft.Json;

namespace Common.Entities
{
    public static class ResultFactory
    {
        public static BaseResult Create()
        {
            return new BaseResult();
        }

        public static BaseResult<T> Create<T>(T wrapped)
        {
            return new BaseResult<T>(wrapped);
        }

        public static BaseResult<T> Wrap<T>(this T wrapped)
        {
            return Create(wrapped);
        }
    }

    public class BaseResult
    {
        public BaseResult()
        {
            IsValid = true;
        }

        public void Apply(BaseResult value)
        {
            IsValid = value.IsValid;
            Error = value.Error;
        }

        public bool IsValid { get; set; }

        [JsonIgnore]
        public BaseError Error { get; set; }

        public virtual void ResolveError(string code, string errorMessage)
        {
            IsValid = false;

            Error = new BaseError();
            Error.Message = errorMessage;
            Error.Code = code;
        }
    }

    public class BaseResult<T> : BaseResult
    {
        public T Object { get; set; }

        public void Apply(BaseResult<T> value)
        {
            Object = value.Object;
            IsValid = value.IsValid;
            Error = value.Error;
        }

        public BaseResult()
        {
            IsValid = true;
        }

        public BaseResult(T wrapped)
        {
            Object = wrapped;
            IsValid = true;
        }
    }
}