using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLearningAcademic.BLL.Services.Contracts.Email;
using VirtualLearningAcademic.DTO.SendEmail;

namespace VirtualLearningAcademic.BLL.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(SendEmailDTO request)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(request.ForUser));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Content
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );

            smtp.Authenticate(
                _configuration.GetSection("Email:UserName").Value,
                _configuration.GetSection("Email:PassWord").Value
                );

            smtp.Send(email);
            smtp.Disconnect(true);




        }
    }
}
