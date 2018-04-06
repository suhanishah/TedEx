using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TedEx.Models
{
    public class Attendance
    {
        public Event Event { get; set; }

        [Key]
        [Column(Order = 1)]
        public int EventId { get; set; }

        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}