using System;
using System.ComponentModel.DataAnnotations;

namespace TedEx.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Speaker { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public Topic Topic { get; set; }
    }
}