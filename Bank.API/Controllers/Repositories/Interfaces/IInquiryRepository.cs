using Bank.API.Models.Inquiries;

namespace Bank.API.Controllers.Repositories.Interfaces
{
    public interface IInquiryRepository
    {
        Task<IEnumerable<Inquiry>> GetAllInquiriesAsync();
        Task<IEnumerable<Inquiry>> GetOnlyChosenInquiriesAsync();
        Task<Inquiry?> GetInquiryByIdAsync(Guid id);
        Task<bool> ChangeInquiryState(Guid id);
        Task<Inquiry> SaveInquiryAsync(Inquiry inquiry);
        Task<bool> SaveAsync();
    }
}
