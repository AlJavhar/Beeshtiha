using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Beeshtiha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync(Message message)
        {
            await emailService.SendEmailAsync(message);
            return Ok();
        }
    }
}
