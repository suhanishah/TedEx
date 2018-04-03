using Microsoft.AspNet.Identity;
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



    }
}

