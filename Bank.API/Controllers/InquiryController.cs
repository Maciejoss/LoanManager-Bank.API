using Bank.API.Models.Inquiries;
using Microsoft.AspNetCore.Mvc;
using Bank.API.DTOs;
using Bank.API.Models.Offers;
using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Repositories.Interfaces;

namespace Bank.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryRepository _inquiryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOfferRepository _offerRepository;

        public InquiryController(IInquiryRepository inquiryRepository, 
            IUserRepository userRepository,
            IOfferRepository offerRepository)
        {
            _inquiryRepository = inquiryRepository;
            _userRepository = userRepository;
            _offerRepository = offerRepository;
        }

        [HttpGet]
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

        [HttpGet("/Only/Chosen")]
        public async Task<ActionResult<List<Inquiry>>> GetOnlyChosenInquiries()
        {
            try
            {
                var inquiries = await _inquiryRepository.GetOnlyChosenInquiriesAsync();
                return inquiries.Count() > 0 ? Ok(inquiries) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Inquiries: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inquiry>> GetInquiryByID(int id)
        {
            try
            {
                var inquiry = await _inquiryRepository.GetInquiryByIdAsync(id);
                return inquiry is not null ? Ok(inquiry) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Inquiry with Id {id}: {ex.Message}");
            }
        }

        [HttpPost("Change/State")]
        public ActionResult ChangeInquiryState(int id)
        {
            try 
            {
                bool result = _inquiryRepository.ChangeInquiryState(id).Result;
                return result ? Ok(result) : NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to change state of Inquiry with Id {id}: {ex.Message}");
            }
        }

        [HttpPost]
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
                
                return Ok(offer);
            }
            catch(Exception ex)
            {
                return BadRequest($"Failed to save Inquiry: {ex.Message}");
            }
        }
    }
}
