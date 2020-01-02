using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace Simplerjiang.AspnetCoreEmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public EmailSender(EmailSettings emailSettings)
        {
            if (emailSettings == null)
            {
                emailSettings = new EmailSettings();
            }
            _emailSettings = emailSettings;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return SendHtmlMail(_emailSettings.MailServer, _emailSettings.MailPort,_emailSettings.UseSSH,_emailSettings.Sender,_emailSettings.Password,_emailSettings.SenderName,_emailSettings.Sender,_emailSettings.ToNickName, email, subject, message);
        }

        private async Task SendHtmlMail(string smtpserver, int port, bool usessh, string account, string pwd, string FromNickName, string FromAccount, string ToNickName, string ToAccount, string Subject, string HtmlContent)
        {
            try
            {
                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress(FromNickName, FromAccount));
                message.To.Add(new MimeKit.MailboxAddress(ToNickName, ToAccount));
                message.Subject = Subject;
                var html = new MimeKit.TextPart("html")
                {
                    Text = HtmlContent
                };
                // create an image attachment for the file located at path
                var alternative = new MimeKit.Multipart("alternative");
                alternative.Add(html);
                // now create the multipart/mixed container to hold the message text and the
                // image attachment 
                var multipart = new MimeKit.Multipart("mixed");
                multipart.Add(alternative);
                message.Body = multipart;
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(smtpserver, port, usessh);
                    // Note: since we don't have an OAuth2 token, disable  
                    // the XOAUTH2 authentication mechanism. 
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: only needed if the SMTP server requires authentication      
                    var mailFromAccount = account;
                    var mailPassword = pwd;
                    client.Authenticate(mailFromAccount, mailPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
