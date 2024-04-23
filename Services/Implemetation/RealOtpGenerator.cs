using EntityFrameworkFromDatabase.Services.Interfaces;

namespace EntityFrameworkFromDatabase.Services.Implemetation
{
    public class RealOtpGenerator : IOtpGenerator
    {
        public string GenerateOtp()
        {
            var r = new Random();
            var otp = r.Next(100000, 999999);
            return otp.ToString();
        }
    }
}
