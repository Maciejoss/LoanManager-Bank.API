using MimeKit;

namespace Bank.API.DTOs
{
    public class MessageDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public MessageDto(string to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
