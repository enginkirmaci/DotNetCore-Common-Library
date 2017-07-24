using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Web.Email
{
    public interface IEmailSender
    {
        SenGridEmailSender Configure(string Key, string FromEmail, string FromName, string DefaultTemplate);

        Task<BaseResult> SendEmailAsync(string toEmail, string subject, string body, string templateId = null, Dictionary<string, string> substitutions = null);
    }
}