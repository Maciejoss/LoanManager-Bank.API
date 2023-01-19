using Bank.API.Models.Users;

namespace Bank.API.DTOs
{
    public class InquiryDto
    {
        public int InquiryID { get; private set; }
        public Guid ClientID { get; private set; }
        public double Value { get; private set; }
        public int InstallmentsNumber { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get => StartDate.AddMonths(InstallmentsNumber); }
        public InquiryDto(Guid clientID, double value, int installmentsNumber, DateTime startDate)
        {
            ClientID = clientID;
            Value = value;
            InstallmentsNumber = installmentsNumber;
            StartDate = startDate;
        }

        public (bool isValid, string message) Validate()
        {
            if (Value <= 0) return (false, "Inquiry Value must be greater provided and greater than '0'");
            if (InstallmentsNumber <= 0) return (false, "Installments Number must be provided and greater than '0'");
            if (DateTime.Now.AddDays(1) > StartDate) return (false, "Start Date must be provided and at least 24h from now");
            return (true, "OK");
        }
    }
}
