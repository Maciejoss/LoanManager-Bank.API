using Bank.API.Models.Inquiries;
using Bank.API.Models.Offers;
using Bank.API.Models.Users;
using Microsoft.EntityFrameworkCore;
using Bank.API.Models.Users.ClientInfo;

namespace Bank.API
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee("pracownik", "jeden", "pracownik.jeden01@gmail.com")
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
                });

            modelBuilder.Entity<GovernmentDocument>().HasData(
                new GovernmentDocument(1, "Driver License", "Driver License", "number")
                {
                    Id = Guid.Parse("9150ebd7-dd84-4c97-bf58-62f1c3611545")
                },
                new GovernmentDocument(2, "Passport", "Passport", "number")
                {
                    Id = Guid.Parse("9150ebd7-dd84-4c97-bf58-62f1c3611554")
                }
            );

            modelBuilder.Entity<JobDetails>().HasData(
                new JobDetails(30, "Director", "Director", DateTime.Now.AddMonths(-5))
                {
                    Id = Guid.Parse("46b087f9-5c71-401f-a5cf-021274463715")
                },
                new JobDetails(37, "Agent", "Agent", DateTime.Now.AddMonths(-15), DateTime.Now.AddDays(-1))
                {
                    Id = Guid.Parse("46b087f9-5c71-401f-a5cf-021274463751")
                }
            );

            modelBuilder.Entity<Client>(b =>
            {
                b.HasData(
                    new 
                    {
                        Id = Guid.Parse("37846734-172e-4149-8cec-6f43d1eb3f60"),
                        Name = "Klient",
                        Surname = "Jeden",
                        Email = "klient.jeden@example.com",
                        GovernmentDocumentId = Guid.Parse("9150ebd7-dd84-4c97-bf58-62f1c3611545"),
                        JobDetailsId = Guid.Parse("46b087f9-5c71-401f-a5cf-021274463715")
                    },
                    new
                    {
                        Id = Guid.Parse("37846734-172e-4149-8cec-6f43d1eb3f06"),
                        Name = "Klient",
                        Surname = "Dwa",
                        Email = "klient.dwa@example.com",
                        GovernmentDocumentId = Guid.Parse("9150ebd7-dd84-4c97-bf58-62f1c3611554"),
                        JobDetailsId = Guid.Parse("46b087f9-5c71-401f-a5cf-021274463751")
                    }
                );
            });
        }
        #endregion

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
