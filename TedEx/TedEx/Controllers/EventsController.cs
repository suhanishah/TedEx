
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

        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Topics = _context.Topics.ToList()
            };
            return View(viewModel);
        }
    }
}