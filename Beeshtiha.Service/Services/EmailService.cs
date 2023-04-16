using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Beeshtiha.Service.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration configuration;

    public EmailService(IConfiguration configuration)
    {
        this.configuration = configuration.GetSection("Email");
    }

    public async Task SendEmailAsync(Message message)
    {
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse(configuration["EmailAddress"]));
        email.To.Add(MailboxAddress.Parse(message.To));

        email.Subject = message.Title;

        email.Body = new TextPart("html")
        {
            Text = message.Body
        };

        var smtp = new SmtpClient();

        await smtp.ConnectAsync(configuration["Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(configuration["EmailAddress"], configuration["Password"]);

        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }
}
