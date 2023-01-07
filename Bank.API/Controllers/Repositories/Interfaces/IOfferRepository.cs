using Bank.API.Models.Offers;

namespace Bank.API.Controllers.Repositories.Interfaces;

public interface IOfferRepository
{
    Task<IEnumerable<Offer>> GetAllOffersAsync();
    Task<Offer?> GetOfferByIdAsync(int id);
    Task<bool> ChangeOfferState(int id);
    Task<Offer> SaveOfferAsync(Offer offer);
    Task<bool> SaveAsync();
}