using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Clara.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _emailOptions;
        private readonly EmailSettings _optionsValue;

        public EmailSender(IOptions<EmailOptions> options, IOptions<EmailSettings> optionsValue)
        {
            _emailOptions = options.Value;
            _optionsValue = optionsValue.Value;
        }

        public async Task sendEmailAsync(string email, string subject, string htmlMessage)
        {
             await Execute(_emailOptions.SendGridKey, subject, htmlMessage, email);
        }

        public async Task SendEmailWithMailGun(string email, string subject, string message)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(_optionsValue.ApiBaseUri) })
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(_optionsValue.ApiKey)));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("from", _optionsValue.From),
                    new KeyValuePair<string, string>("to", email),
                    new KeyValuePair<string, string>("subject", subject),
                    new KeyValuePair<string, string>("html", message)
                });

                await client.PostAsync(_optionsValue.RequestUri, content).ConfigureAwait(false);
            }
        }

        private async Task Execute(string sendGridKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKey);
            var from = new EmailAddress("davidomoigui1000@gmail.com", "Clara Inc");
            var to = new EmailAddress(email, "End User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);
            var response = await  client.SendEmailAsync(msg);
        }
    }
}
