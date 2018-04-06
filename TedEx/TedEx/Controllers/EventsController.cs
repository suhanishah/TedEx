using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TedEx.Models;
using TedEx.ViewModels;

namespace TedEx.Controllers
{

    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }



        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Topics = _context.Topics.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Topics = _context.Topics.ToList();
                return View("Create", viewModel); // Create View, viewModel - so that
                //all values will be in there with validation messages
            }


            var event1 = new Event()
            {
                SpeakerId = User.Identity.GetUserId(),
                TopicId = viewModel.Topic,
                DateTime = viewModel.GetDateTime(),
                Venue = viewModel.Venue
            };

            _context.Events.Add(event1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var userAttendingEvents =
                _context.Attendances.
                    Where(a => a.AttendeeId == userId)
                    .Select(a => a.Event)
                    .Include(e => e.Speaker)
                    .Include(e => e.Topic)
                    .ToList();

            var viewModel = new HomeViewModel()
            {
                UpcomingEvents = userAttendingEvents,
                ShowAuthentication = User.Identity.IsAuthenticated,
                Heading = "Events You're Attending"
            };
            return View("Events", viewModel);
        }



    }
}

