using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Common.Web.Middlewares
{
    public class NonWwwRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public NonWwwRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Host.ToString();

            if (url.Contains("www."))
            {
                context.Response.Redirect(url.Replace("www.", context.Request.Scheme + "://") + context.Request.Path.ToString(), true);
            }
            else
            {
                await _next(context);
            }
        }
    }
}