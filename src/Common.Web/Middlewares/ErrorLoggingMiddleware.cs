using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Common.Web.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public ErrorLoggingMiddleware(RequestDelegate next, ILogger logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseError ex)
            {
                string identityName = context.User.Identity.Name;
                using (_logger.BeginScope("{Code} {CreatedBy} {WebsiteGuid}", ex.Code, identityName, _configuration["Settings:Website"]))
                {
                    _logger.LogError(0, ex, ex.Message);
                }

                throw; // Don't stop the error
            }
            catch (Exception ex)
            {
                string identityName = context.User.Identity.Name;

                if (!string.IsNullOrEmpty(identityName))
                    using (_logger.BeginScope("{CreatedBy} {WebsiteGuid}", identityName, _configuration["Settings:Website"]))
                    {
                        _logger.LogError(0, ex, ex.Message);
                    }
                else
                    using (_logger.BeginScope("{WebsiteGuid}", _configuration["Settings:Website"]))
                    {
                        _logger.LogError(0, ex, ex.Message);
                    }

                throw; // Don't stop the error
            }
        }
    }
}