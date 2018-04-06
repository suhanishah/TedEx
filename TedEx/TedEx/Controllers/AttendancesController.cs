using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TedEx.Dtos;
using TedEx.Models;

namespace TedEx.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(e => e.AttendeeId == userId && e.EventId == dto.EventId))
                return BadRequest("Your attendence already exists. We will be waiting for you.");

            var attendance = new Attendance()
            {
                EventId = dto.EventId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
