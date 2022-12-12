﻿using Bank.API.Models.Inquiries;
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
        private readonly IInquiryRepository inquiryRepository;
        private readonly IUserRepository userRepository;

        public InquiryController(IInquiryRepository _inquiryRepository, IUserRepository _userRepository)
        {
            inquiryRepository = _inquiryRepository;
            userRepository = _userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Inquiry>>> GetInquiries()
        {
            try
            {
                var inquiries = await inquiryRepository.GetAllInquiriesAsync();
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
                var inquiry = await inquiryRepository.GetInquiryByIdAsync(id);
                return inquiry is not null ? Ok(inquiry) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Inquiry with Id {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Offer>> SaveInquiry([FromBody] InquiryDto inquiryDto)
        {
            try
            {
                var validationResult = inquiryDto.Validate();
                if (!validationResult.isValid) return BadRequest(validationResult.message);

                var client = await userRepository.GetClientByIdAsync(inquiryDto.ClientID);
                if (client is null) return NotFound();
                Inquiry inquiry = new Inquiry(client, inquiryDto);

                await inquiryRepository.SaveInquiryAsync(inquiry);

                return Ok(new Offer(inquiry));
            }
            catch(Exception ex)
            {
                return BadRequest($"Failed to save Inquiry: {ex.Message}");
            }
        }
    }
}