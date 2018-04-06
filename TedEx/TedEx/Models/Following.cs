using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TedEx.Models
{
    public class Following
    {
        public ApplicationUser Follower { get; set; }

        public ApplicationUser Followee { get; set; } // person who is being followed - in our case Speaker

        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }
    }
}