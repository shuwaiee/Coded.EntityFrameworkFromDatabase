using EntityFrameworkFromDatabase.Models;
using EntityFrameworkFromDatabase.Services;
using EntityFrameworkFromDatabase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFrameworkFromDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext _context;
        private readonly IEmailService _emailService;
        private IOtpGenerator _otp;
        public HomeController(
            StudentDbContext context,
            IEmailService emailService,
            IOtpGenerator otpGenerator)
        {
            _context = context;
            _emailService = emailService;
            _otp = otpGenerator;
        }

        public IActionResult Index()
           
        {
           //  var db = new StudentDbContext();
            _emailService.Send("m.shuwaee@gmaio.com","Test","Test");
            //var email = new ExchangeeMailService(new DbContext());
            //Console.WriteLine(otp.GenerateOtp());
            return View(_context.Students.Include(r=> r.Department).ToList());
            return View();
        }

        public IActionResult Privacy()
        {

            emailService.Send("m.shuwaee@gmaio.com", "Test", "Test");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            emailService.Send("m.shuwaee@gmaio.com", "Test", "Test");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
