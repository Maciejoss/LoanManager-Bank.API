namespace Bank.API.Services.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
