using Bank.API.Models.Users;

namespace Bank.API.Controllers.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Client?> GetClientByIdAsync(Guid id);
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task<Employee?> GetEmployeeByEmailAsync(string email);
        Task<bool> SaveAsync();

    }
}
