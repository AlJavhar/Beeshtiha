using Beeshtiha.Domain.Entities;

namespace Beeshtiha.Service.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(Message message);
}
