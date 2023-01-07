using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Models.Inquiries;
using Bank.API.Models.Offers;
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
            return await bankContext.Offers.ToListAsync();
        }
        
        public async Task<Offer?> GetOfferByIdAsync(int id)
        {
            return await bankContext.Offers.FindAsync(id);
        }

        public Task<bool> ChangeOfferState(int id)
        {
            throw new NotImplementedException();
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
