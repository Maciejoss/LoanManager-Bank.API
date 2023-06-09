﻿using Bank.API.Controllers.Repositories.Interfaces;
using Bank.API.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpGet("Clients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            try
            {
                var clients = await userRepository.GetAllClientsAsync();
                return clients.Count() > 0 ? Ok(clients) : NotFound();
            }
            catch (Exception ex)
            {
                return NotFound($"Failed to get Clients: {ex.Message}");
            }
        }

        [HttpGet("Employees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Client>>> GetEmployees()
        {
            try
            {
                var employees = await userRepository.GetAllEmployeesAsync();
                return employees.Count() > 0 ? Ok(employees) : NotFound();
            }
            catch (Exception ex)
            {
                return NotFound($"Failed to get Employees: {ex.Message}");
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Employee/{id:Guid}")]
        public async Task<ActionResult<Employee>> GetEmployeeByID(Guid id)
        {
            try
            {
                var employee = await userRepository.GetEmployeeByIdAsync(id);
                return employee is not null ? Ok(employee) : NotFound();
            }
            catch (Exception ex)
            {
                return NotFound($"Failed to get Employee with Id {id}: {ex.Message}");
            }
        }
        
        [HttpGet("Employee/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {
            try
            {
                var employee = await userRepository.GetEmployeeByEmailAsync(email);
                return employee is not null ? Ok(employee) : NotFound();
            }
            catch (Exception ex)
            {
                return NotFound($"Failed to get Employee with email {email}: {ex.Message}");
            }
        }
    }
}
