using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Models.Inquiries;
using Bank.API.Services.PdfService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PdfSharp.Pdf.IO;

namespace Bank.API.Controllers.Repositories
{
    public class InquiryRepository : IInquiryRepository
    {
        private readonly BankContext _bankContext;

        public InquiryRepository(BankContext context)
        {
           _bankContext = context;
        }
        public async Task<IEnumerable<Inquiry>> GetAllInquiriesAsync()
        {
            return await _bankContext.Inquiries
                .Include(i => i.Client.GovernmentDocument)
                .Include(i => i.Client.JobDetails)
                .ToListAsync();
        }

        public async Task<Inquiry?> GetInquiryByIdAsync(int id)
        {
            return await _bankContext.Inquiries
                .Include(i => i.Client.GovernmentDocument)
                .Include(i => i.Client.JobDetails)
                .FirstOrDefaultAsync(i => i.InquiryID == id);
        }

        public async Task<Inquiry> SaveInquiryAsync(Inquiry inquiry)
        {
            await _bankContext.Inquiries.AddAsync(inquiry);
            await SaveAsync();
            return inquiry;
        }

        public async Task<bool> SaveAsync()
        {
            return await _bankContext.SaveChangesAsync() > 0;
        }
    }
}
