namespace Bank.API.Controllers.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
