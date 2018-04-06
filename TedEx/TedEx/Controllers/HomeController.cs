using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TedEx.Models;
using TedEx.ViewModels;

namespace TedEx.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingEvents = _context.Events
                .Include(e => e.Speaker)
                .Include(e => e.Topic)
                .Where(e => e.DateTime > DateTime.Now);

            var viewModel = new HomeViewModel()
            {
                UpcomingEvents = upcomingEvents,
                ShowAuthentication = User.Identity.IsAuthenticated,
                Heading = "Upcoming Events"
            };
            return View("Events", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}