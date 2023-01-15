using Bank.API.Controllers.Repositories;
using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.DTOs;
using Bank.API.Models.Offers;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers;

[Route("[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
    private IOfferRepository _offerRepository;
    
    public OfferController(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Offer>> GetOfferByID(int id)
    {
        try
        {
            var offer = await _offerRepository.GetOfferByIdAsync(id);
            return offer is not null ? Ok(offer) : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to get Offer with Id {id}: {ex.Message}");
        }
    }

    [HttpPost("Change/State")]
    public ActionResult ChangeOfferState([FromBody] ChangeOfferStateDTO changeOfferStateDTO)
    {
        try
        {
            bool result = _offerRepository.ChangeOfferState(changeOfferStateDTO.id, changeOfferStateDTO.employeeId, changeOfferStateDTO.status).Result;
            return result ? Ok(result) : NotFound();

        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to change state of Offer with Id {changeOfferStateDTO.id}: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Offer>>> GetOffers()
    {
        try
        {
            var offers = await _offerRepository.GetAllOffersAsync();
            return offers.Count() > 0 ? Ok(offers) : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to get Offers: {ex.Message}");
        }
    }
    
    [HttpGet("{id}/document")]
    public async Task<ActionResult<Offer>> GetPdfFile(int id)
    {
        try
        {
            var offer = await _offerRepository.GetOfferByIdAsync(id);
            return offer is not null ? Ok(offer) : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to get Offer with Id {id}: {ex.Message}");
        }
    }
   
    //todo create HttpPost to post document to blob storage
}