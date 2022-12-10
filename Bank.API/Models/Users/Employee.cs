namespace Bank.API.Models.Users
{
    public class Employee : User
    {
        public Employee(string name, string surname, string email) : base(name, surname, email) { }
        public Employee() { }
    }
}
