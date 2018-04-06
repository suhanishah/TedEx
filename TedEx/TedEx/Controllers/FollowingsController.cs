using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TedEx.Dtos;
using TedEx.Models;

namespace TedEx.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Followings.Any
            (f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId);

            if (exists)
                return BadRequest("You are already following this Speaker");

            var following = new Following()
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
