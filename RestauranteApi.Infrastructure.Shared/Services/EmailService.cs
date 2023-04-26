﻿
using RestauranteApi.Core.Domain.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestauranteApi.Core.Application.Dtos.Email;
using RestauranteApi.Core.Application.IServices;

namespace RestauranteApi.Infrastructure.Shared.Services
{
    public class EmailService : IEmailService
    {
        private EmailSettings mailSettings { get; }

        public EmailService(IOptions<EmailSettings> mailsettings)
        {
            this.mailSettings = mailsettings.Value;
        }
        public async Task SendAsync(EmailRequest email)
        {
            try
            {
                MimeMessage correo = new();
                correo.Sender = MailboxAddress.Parse(mailSettings.DisplayName + "<" + mailSettings.Emailfrom + ">");
                correo.To.Add(MailboxAddress.Parse(email.To));
                correo.Subject = email.Subject;
                BodyBuilder builder = new();
                builder.HtmlBody = email.Body;
                correo.Body = builder.ToMessageBody();

                //using System.Net.Mail.SmtpClient smpt = new();
                //smpt.ServerCertificateValidationCallback = (s, c, h, e) => true;
                //smpt.Connect(mailSettings.SmtpHost, mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                //smpt.Authenticate(mailSettings.SmtpUser, mailSettings.SmtpPass);
                //await smpt.SendAsync(correo);
                //smpt.Disconnect(true);

                //await emailService.SendAsync(new EmailRequest
                //{ 
                //To = user.email;
                //Subject = "Klk";
                //Body = "";
                //});
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
