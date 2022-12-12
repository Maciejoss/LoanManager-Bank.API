using Bank.API.Models.Inquiries;
using Bank.API.Models.Offers;
using Bank.API.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Bank.API
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee("pracownik", "jeden", "pracownik.jeden01@gmail.com"));
        }
        #endregion

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
