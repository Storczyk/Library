using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Extensions.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var msg = new MimeMessage(); ///////////////////////////////////////////////
            msg.From.Add(new MailboxAddress("Pawel Sroczyk", "testingpgsapp@gmail.com"));
            msg.To.Add(new MailboxAddress(email));
            msg.Subject = subject;
            msg.Body = new TextPart(TextFormat.Html)
            {
                Text = message
            };

            using(var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                ///////////////////////////////////////////////////////////
                client.Authenticate("testingpgsapp", "pgsnajlepszy");
                client.Send(msg);
                client.Disconnect(true);
            }
            return Task.CompletedTask;
        }
    }
}
