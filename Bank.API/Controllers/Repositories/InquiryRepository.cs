using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Models.Inquiries;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Bank.API.Controllers.Repositories
{
    public class InquiryRepository : IInquiryRepository
    {
        private readonly BankContext bankContext;

        public InquiryRepository(BankContext context)
        {
            bankContext = context;
        }
        public async Task<IEnumerable<Inquiry>> GetAllInquiriesAsync()
        {
            return await bankContext.Inquiries.ToListAsync();
        }

        public async Task<Inquiry?> GetInquiryByIdAsync(int id)
        {
            return await bankContext.Inquiries.FindAsync(id);
        }

        public async Task<Inquiry> SaveInquiryAsync(Inquiry inquiry)
        {
            await bankContext.Inquiries.AddAsync(inquiry);
            await SaveAsync();
            return inquiry;
        }

        public async Task<bool> SaveAsync()
        {
            return await bankContext.SaveChangesAsync() > 0;
        }
    }
}
