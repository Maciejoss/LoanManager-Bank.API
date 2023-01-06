using Bank.API.Models.Inquiries;

namespace Bank.API.Controllers.Repositories.Interfaces
{
    public interface IInquiryRepository
    {
        Task<IEnumerable<Inquiry>> GetAllInquiriesAsync();
        Task<IEnumerable<Inquiry>> GetOnlyChosenInquiriesAsync();
        Task<Inquiry?> GetInquiryByIdAsync(int id);
        Task<bool> ChangeInquiryState(int id);
        Task<Inquiry> SaveInquiryAsync(Inquiry inquiry);
        Task<bool> SaveAsync();
    }
}
