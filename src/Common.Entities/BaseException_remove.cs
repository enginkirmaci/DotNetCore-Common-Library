using System;

namespace Common.Entities
{
    //TODO rc2 bug// [Serializable]
    public class BaseException : Exception
    {
        public int Code { get; set; }

        public string CreatedBy { get; set; }

        public BaseException()
        : base()
        { }

        public BaseException(string message)
        : base(message)
        { }

        public BaseException(string format, params object[] args)
        : base(string.Format(format, args))
        { }

        public BaseException(string message, Exception innerException)
        : base(message, innerException)
        { }

        public BaseException(int code, string message, Exception innerException)
        : base(message, innerException)
        {
            Code = code;
        }

        public BaseException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException)
        { }

        //TODO rc2 bug// Serialization
        //protected BaseException(SerializationInfo info, StreamingContext context)
        //: base(info, context)
        //{ }
    }
}