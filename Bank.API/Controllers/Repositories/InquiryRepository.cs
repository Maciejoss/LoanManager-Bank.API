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
            return await _bankContext.Inquiries.ToListAsync();
        }

        public async Task<IEnumerable<Inquiry>> GetOnlyChosenInquiriesAsync()
        {
            return await _bankContext.Inquiries
                .Where(i => i.State == InquiryState.chosenByClient)
                .ToListAsync();
        }

        public async Task<Inquiry?> GetInquiryByIdAsync(int id)
        {
            return await _bankContext.Inquiries.FindAsync(id);
        }

        public async Task<bool> ChangeInquiryState(int id)
        {
            var inquiry = GetInquiryByIdAsync(id).Result;

            if (inquiry is not null)
            {
                inquiry.State = InquiryState.chosenByClient;
                return await SaveAsync();
            }
            return false;
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
