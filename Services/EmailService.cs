using EntityFrameworkFromDatabase.Models;
using EntityFrameworkFromDatabase.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace EntityFrameworkFromDatabase.Services
{

    public class FakeMailService : IEmailService
    {
        public void Send(string to, string subject, string body)
        {
            // Email Sending Logic
            Console.WriteLine("Fake Sending Email");
        }
    }
    public class ExchangeeMailService : IEmailService
    {
        public ExchangeeMailService(StudentDbContext context)
        {
            this.context = context;
        }
        int howManyCalls = 0;
        private readonly StudentDbContext context;

        public void Send(string to, string subject, string body)
        {
            // Email Sending Logic
            howManyCalls++;
            Console.WriteLine($"Exchange Sending Email Called {howManyCalls}");
        }
    }
    public class Office365EmailService : IEmailService
    {
        public void Send(string to, string subject, string body)
        {
            // Email Sending Logic
            Console.WriteLine("Office 365 Sending Email");
        }
    }
}
