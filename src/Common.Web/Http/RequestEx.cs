using Microsoft.AspNetCore.Http;
using System;

namespace Common.Web.Http
{
    public static class RequestEx
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            //if (request["X-Requested-With"] == "XMLHttpRequest")
            //    return true;
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
    }
}