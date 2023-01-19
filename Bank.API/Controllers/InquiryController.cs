using Bank.API.Models.Inquiries;
using Microsoft.AspNetCore.Mvc;
using Bank.API.DTOs;
using Bank.API.Models.Offers;
using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Services.BlobStorageService;
using Bank.API.Services.EmailService;
using Bank.API.Services.PdfService;

namespace Bank.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryRepository _inquiryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly BlobStorageManager _blobStorage;
        private readonly PdfCreator _pdfService;
        private readonly IEmailSender _emailService;
        public InquiryController(IInquiryRepository inquiryRepository, 
            IUserRepository userRepository,
            IOfferRepository offerRepository,
            BlobStorageManager storageManager,
            PdfCreator pdfService,
            IEmailSender emailService)
        {
            _inquiryRepository = inquiryRepository;
            _userRepository = userRepository;
            _offerRepository = offerRepository;
            _blobStorage = storageManager;
            _pdfService = pdfService;
            _emailService = emailService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Inquiry>>> GetInquiries()
        {
            try
            {
                var inquiries = await _inquiryRepository.GetAllInquiriesAsync();
                return inquiries.Count() > 0 ? Ok(inquiries) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Inquiries: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Inquiry>> GetInquiryByID(int id)
        {
            try
            {
                var inquiry = await _inquiryRepository.GetInquiryByIdAsync(id);
                return inquiry is not null ? Ok(inquiry) : NotFound();
            }
            catch (Exception ex)
            {
                return NotFound($"Failed to get Inquiry with Id {id}: {ex.Message}");
            }
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Offer>> SaveInquiry([FromBody] InquiryDto inquiryDto)
        {
            try
            {
                var validationResult = inquiryDto.Validate();
                if (!validationResult.isValid) return BadRequest(validationResult.message);

                var client = await _userRepository.GetClientByIdAsync(inquiryDto.ClientID);
                if (client is null) return NotFound();
                
                Inquiry inquiry = new Inquiry(client, inquiryDto);
                await _inquiryRepository.SaveInquiryAsync(inquiry);
                
                var offer = new Offer(inquiry);
                await _offerRepository.SaveOfferAsync(offer);
                var document = _pdfService.CreateDocument(offer.OfferID);
                await _blobStorage.Upload(offer.OfferID, document);

                var email = new Message(new MessageDto(
                    client.Email,
                    $"Loan request for {client.Name}",
                    "Hello, we have just received your loan request"));
                _emailService.SendEmail(email);
                
                return Ok(offer);
            }
            catch(Exception ex)
            {
                return BadRequest($"Failed to save Inquiry: {ex.Message}");
            }
        }
    }
}
