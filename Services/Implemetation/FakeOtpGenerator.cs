using EntityFrameworkFromDatabase.Services.Interfaces;

namespace EntityFrameworkFromDatabase.Services.Implemetation
{
    public class FakeOtpGenerator : IOtpGenerator
    {
        public string GenerateOtp()
        {
            return "000000";
        }
    }
}
