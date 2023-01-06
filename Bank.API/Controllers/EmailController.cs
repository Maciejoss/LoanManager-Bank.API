using Bank.API.DTOs;
using Bank.API.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender emailSender;

        public EmailController(IEmailSender _emailSender)
        {
            emailSender = _emailSender;
        }

        [HttpPut]
        public void SendEmail([FromBody] MessageDto messageDto)
        {
            var message = new Message(messageDto);
            emailSender.SendEmail(message);
        }
    }
}
