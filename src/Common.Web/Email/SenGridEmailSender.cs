using Common.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Web.Email
{
    public class SenGridEmailSender : IEmailSender
    {
        public string Key { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string DefaultTemplate { get; set; }

        public SenGridEmailSender Configure(string Key, string FromEmail, string FromName, string DefaultTemplate)
        {
            this.Key = Key;
            this.FromEmail = FromEmail;
            this.FromName = FromName;
            this.DefaultTemplate = DefaultTemplate;

            return this;
        }

        public async Task<BaseResult> SendEmailAsync(string toEmail, string subject, string body, string templateId = null, Dictionary<string, string> substitutions = null)
        {
            var result = ResultFactory.Create();

            templateId = !string.IsNullOrEmpty(templateId) ? templateId : DefaultTemplate;

            try
            {
                var client = new SendGridClient(Key);

                var msg = new SendGridMessage();
                msg.SetFrom(new EmailAddress(FromEmail, FromName));
                msg.SetSubject(subject);
                //msg.AddContent(MimeType.Text, "Hello, Email from the helper [SendSingleEmailAsync]!");
                msg.AddContent(MimeType.Html, body);
                msg.AddTo(new EmailAddress(FromEmail, FromName));
                msg.SetClickTracking(true, false);

                if (templateId != null)
                {
                    msg.TemplateId = templateId;

                    foreach (var field in substitutions)
                        msg.AddSubstitution("#" + field.Key + "#", field.Value);

                    //mail.Personalization[0].AddSubstitution("-name-", "Example User");
                    //mail.Personalization[0].AddSubstitution("-city-", "Denver");
                }

                var response = await client.SendEmailAsync(msg);
            }
            catch
            {
                result.ResolveError("EMAIL_SEND_ERROR", "Email gönderimi sırasında hata meydana geldi. Lütfen tekrar deneyiniz.");
            }

            return result;
        }
    }
}