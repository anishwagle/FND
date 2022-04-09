using FND.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FND.Middlewares;
using FND.DAO;
using FND.Models;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.IO;

namespace FND.Services.Impl
{
    public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;
    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(string emailTo,string subject, string body){
    var email = new MimeMessage();
    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
    email.To.Add(MailboxAddress.Parse(emailTo));
    email.Subject = subject;
    var builder = new BodyBuilder();
    
    builder.HtmlBody = body;
    email.Body = builder.ToMessageBody();
    using var smtp = new SmtpClient();
    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
    await smtp.SendAsync(email);
    smtp.Disconnect(true);
}
}
}