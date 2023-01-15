using Bank.API.DTOs;
using Bank.API.Models.Users;

namespace Bank.API.Models.Inquiries
{
    public class Inquiry
    {
        public int InquiryID { get; private set; }
        public Client Client { get; private set; }
        public double Value { get; private set; }
        public int InstallmentsNumber { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get => StartDate.AddMonths(InstallmentsNumber); }        

        public Inquiry(Client client, InquiryDto inquiryDto)
        {
            Client = client;
            Value = inquiryDto.Value;
            InstallmentsNumber = inquiryDto.InstallmentsNumber;
            StartDate = inquiryDto.StartDate;
        }

        public Inquiry() { }
    }
}
