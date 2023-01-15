using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Models.Inquiries;
using Bank.API.Models.Offers;
using Bank.API.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Bank.API.Controllers.Repositories
{
    public class OfferRepository: IOfferRepository
    {
        private readonly BankContext bankContext;

        public OfferRepository(BankContext context)
        {
            bankContext = context;
        }

        public async Task<Inquiry> SaveInquiryAsync(Inquiry inquiry)
        {
            await bankContext.Inquiries.AddAsync(inquiry);
            await SaveAsync();
            return inquiry;
        }

        public async Task<IEnumerable<Offer>> GetAllOffersAsync()
        {
            return await bankContext.Offers
                .Include(o => o.Reviewer)
                .ToListAsync();
        }
        
        public async Task<Offer?> GetOfferByIdAsync(int id)
        {
            return await bankContext.Offers
                .Include(o => o.Reviewer).
                FirstOrDefaultAsync(o => o.OfferID == id);
        }

        public async Task<bool> ChangeOfferState(int id, Guid employeeId, OfferStatus status)
        {
            Offer? offer = await bankContext.Offers.FindAsync(id);
            Employee? employee = await bankContext.Employees.FindAsync(employeeId);
            if (offer is not null && employee is not null)
            {
                offer.UpdateStatus(employee, status);
                return await SaveAsync();
            }            
            return false;
        }

        public async Task<Offer> SaveOfferAsync(Offer offer)
        {
            await bankContext.Offers.AddAsync(offer);
            await SaveAsync();
            return offer;
        }

        public async Task<bool> SaveAsync()
        {
            return await bankContext.SaveChangesAsync() > 0;
        }
    }
}
