using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace PROJECT.Core.Helpers
{
    public class GmailEmail
    {
        private readonly SmtpConfiguration _config;

        private const string GmailUserNameKey = "GmailUserName";
        private const string GmailPasswordKey = "GmailPassword";
        private const string GmailHostKey = "GmailHost";
        private const string GmailPortKey = "GmailPort";
        private const string GmailSslKey = "GmailSsl";

        public GmailEmail()
        {
            _config = new SmtpConfiguration();
            var gmailUserName = ConfigurationManager.AppSettings[GmailUserNameKey];
            var gmailPassword = ConfigurationManager.AppSettings[GmailPasswordKey];
            var gmailHost = ConfigurationManager.AppSettings[GmailHostKey];
            var gmailPort = Int32.Parse(ConfigurationManager.AppSettings[GmailPortKey]);
            var gmailSsl = Boolean.Parse(ConfigurationManager.AppSettings[GmailSslKey]);
            _config.Username = gmailUserName;
            _config.Password = gmailPassword;
            _config.Host = gmailHost;
            _config.Port = gmailPort;
            _config.Ssl = gmailSsl;
        }

        public bool SendEmailMessage(EmailMessage message)
        {
            var success = false;
            try
            {
                var smtp = new SmtpClient
                {
                    Host = _config.Host,
                    Port = _config.Port,
                    EnableSsl = _config.Ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.Username, _config.Password)
                };

                using (var smtpMessage = new MailMessage(_config.Username, message.ToEmail))
                {
                    smtpMessage.Subject = message.Subject;
                    smtpMessage.Body = message.Body;
                    smtpMessage.IsBodyHtml = message.IsHtml;
                    smtp.Send(smtpMessage);
                }

                success = true;
            }
            catch (Exception ex)
            {
                //todo: add logging integration
                throw ex;
            }

            return success;
        }
    }


    public class SmtpConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }

    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }

}