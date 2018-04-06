using System.Collections.Generic;
using TedEx.Models;

namespace TedEx.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public bool ShowAuthentication { get; set; }
        public string Heading { get; set; }
    }
}