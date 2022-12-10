using Bank.API.Models.Users;
using Bank.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankContext bankContext;

        public UserRepository(BankContext context)
        {
            bankContext = context;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await bankContext.Clients.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await bankContext.Employees.ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(Guid id)
        {
            return await bankContext.Clients.FindAsync(id);
        }        

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await bankContext.Employees.FindAsync(id);
        }

        public async Task<Employee?> GetEmployeeByEmailAsync(string email)
        {
            return await bankContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<bool> SaveAsync()
        {
            return await bankContext.SaveChangesAsync() > 0;
        }
    }
}
