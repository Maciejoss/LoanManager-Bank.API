using Bank.API.DTOs;
using Bank.API.Models.Offers;
using Bank.API.Models.Users;

namespace Bank.API.Controllers.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> GetAllOffersAsync();
        Task<Offer?> GetOfferByIdAsync(int id);
        Task<bool> ChangeOfferState(int id, Guid employeeId, OfferStatus status);
        Task<Offer> SaveOfferAsync(Offer offer);
        Task<bool> SaveAsync();
    }
}