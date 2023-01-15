using Bank.API.Models.Offers;

namespace Bank.API.DTOs
{
    public class ChangeOfferStateDTO
    {
        public int id { get; set; }
        public Guid employeeId { get; set; }
        public OfferStatus status { get; set; }

        public ChangeOfferStateDTO() { }
    }
}
