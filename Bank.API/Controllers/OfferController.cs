using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Models.Offers;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers;

[Route("[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
    private IOfferRepository _offerRepository;
    
    OfferController(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Offer>> GetOfferByID(Guid id)
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
    
    [HttpGet("file/{id}")]
    public async Task<ActionResult<Offer>> GetPdfFile(Guid id)
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
}