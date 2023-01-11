using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Models.Offers;
using Bank.API.Services.BlobStorageService;
using Bank.API.Services.PdfService;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers.Repositories
{
    public class OfferRepository: IOfferRepository
    {
        private readonly BankContext _bankContext;
        private readonly PdfCreator _pdfService;
        private readonly BlobStorageManager _blobStorage;
        
        public OfferRepository(BankContext context, PdfCreator pdfService, BlobStorageManager blobContext)
        {
            _bankContext = context;
            _pdfService = pdfService;
            _blobStorage = blobContext;
        }

        public async Task<IEnumerable<Offer>> GetAllOffersAsync()
        {
            return await _bankContext.Offers.ToListAsync();
        }
        
        public async Task<Offer?> GetOfferByIdAsync(int id)
        {
            return await _bankContext.Offers.FindAsync(id);
        }

        public Task<bool> ChangeOfferState(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Offer> SaveOfferAsync(Offer offer)
        {
            await _bankContext.Offers.AddAsync(offer);
            await SaveAsync();
            var document = _pdfService.CreateDocument(offer.OfferID);
            await _blobStorage.Upload(offer.OfferID, document);
            return offer;
        }

        public async Task<bool> SaveAsync()
        {
            return await _bankContext.SaveChangesAsync() > 0;
        }
    }
}
