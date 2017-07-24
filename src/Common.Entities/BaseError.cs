using System;

namespace Common.Entities
{
    public class BaseError : Exception
    {
        public string Code { get; set; }

        public new string Message { get; set; }

        public BaseError()
        : base()
        { }

        //public BaseError(string message)
        //: base(message)
        //{ }

        //public BaseError(string format, params object[] args)
        //: base(string.Format(format, args))
        //{ }

        public BaseError(string code, string message, Exception innerException)
        : base(message, innerException)
        {
            Code = code;
            Message = message;
        }

        //public BaseError(string code, string message, Exception innerException)
        //: base(message, innerException)
        //{
        //    Code = code;
        //}

        //public BaseError(string format, Exception innerException, params object[] args)
        //: base(string.Format(format, args), innerException)
        //{ }

        //protected BaseError(SerializationInfo info, StreamingContext context)
        //: base(info, context)
        //{ }
    }
}