using Common.Entities.Enums;

namespace Common.Entities
{
    public class TransactionResult
    {
        public TransactionResult()
        {
        }

        public TransactionResult(int code = 0, string returnUrl = null, string message = null, TransactionType type = TransactionType.None, object result = null)
        {
            Code = code;
            ReturnUrl = returnUrl;
            Message = message;
            Type = type;
            Result = result;
        }

        public int Code { get; set; }

        public string ReturnUrl { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public TransactionType Type { get; set; }
    }
}