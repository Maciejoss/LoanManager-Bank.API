using Bank.API.Models.Inquiries;
using Bank.API.Models.Users;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Models.Offers
{
    public enum Status
    {
        Created,
        Approved,
        Declined,
    }
    public class Offer
    {
        [Key]
        public int OfferID { get; private set; }
        public double Percentage { get; private set; }
        public double MonthlyInstallment { get; private set; }
        public double RequestedValue { get; private set; }
        public int RequestedPeriodInMonth { get; private set; }
        public int StatusID { get; private set; }
        public string StatusDescription { get => ((Status)StatusID).ToString(); }
        public int InquiryID { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public Employee? Reviewer { get; private set; }
        public Uri? DocumentLink { get; private set; }
        public DateTime DocumentLinkValidDate { get; private set; }

        public Offer(Inquiry inquiry)
        {
            Percentage = 0.05;
            RequestedValue = inquiry.Value;
            RequestedPeriodInMonth = inquiry.InstallmentsNumber;
            MonthlyInstallment = RequestedValue * Percentage * Math.Pow(1 + Percentage, RequestedPeriodInMonth) /
                (Math.Pow(1 + Percentage, RequestedPeriodInMonth) - 1);
            StatusID = (int)Status.Created;
            InquiryID = inquiry.InquiryID;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            DocumentLinkValidDate = DateTime.Now;
        }
        public Offer() { }
        public void UpdateOfferStatus(Employee employee, Status status)
        {
            StatusID = (int)status;
            UpdateDate = DateTime.Now;
            Reviewer = employee;
        }

        public void UploadDocument(Uri documentLink)
        {
            DocumentLink = documentLink;
            DocumentLinkValidDate = DateTime.Now.AddYears(1);
        }
    }
}
