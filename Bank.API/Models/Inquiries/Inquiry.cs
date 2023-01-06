using Bank.API.DTOs;
using Bank.API.Models.Users;

namespace Bank.API.Models.Inquiries
{
    public enum InquiryState : byte
    {
        created,
        chosenByClient,
    }
    public class Inquiry
    {
        public Guid InquiryID { get; private set; }
        public Client Client { get; private set; }
        public double Value { get; private set; }
        public int InstallmentsNumber { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get => StartDate.AddMonths(InstallmentsNumber); }        
        public InquiryState State { get; set; }

        public Inquiry(Client client, InquiryDto inquiryDto)
        {
            Client = client;
            Value = inquiryDto.Value;
            InstallmentsNumber = inquiryDto.InstallmentsNumber;
            StartDate = inquiryDto.StartDate;
            State = InquiryState.created;
        }
        public Inquiry() { }
    }
}
