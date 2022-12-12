using Bank.API.DTOs;
using MimeKit;

namespace Bank.API.Controllers.EmailService
{
    public class Message
    {
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(MessageDto messageDto)
        {
            To = new MailboxAddress(messageDto.To, messageDto.To);
            Subject = messageDto.Subject;
            Content = messageDto.Content;
        }
    }
}
