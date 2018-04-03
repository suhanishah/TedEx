using Microsoft.AspNet.Identity;
using System;
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
            var event1 = new Event()
            {
                SpeakerId = User.Identity.GetUserId(),
                TopicId = viewModel.Topic,
                DateTime = DateTime.Parse(String.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                Venue = viewModel.Venue
            };

            _context.Events.Add(event1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }



    }
}

