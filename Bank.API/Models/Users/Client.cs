using Bank.API.Models.Users.ClientInfo;

namespace Bank.API.Models.Users
{
    public class Client : User
    {
        public JobDetails? JobDetails { get; private set; }
        public GovernmentDocument? GovernmentDocument { get; private set; }

        public Client(string name, string surname, string email) : base(name, surname, email) { }
        public Client(string name, string surname, string email, GovernmentDocument document, JobDetails details) 
            : base(name, surname, email) 
        {
            GovernmentDocument = document;
            JobDetails = details;
        }
        public Client() { }
    }
}
