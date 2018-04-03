using System;
using System.ComponentModel.DataAnnotations;

namespace TedEx.Models
{
    public class Event
    {
        public int Id { get; set; }

        public ApplicationUser Speaker { get; set; }

        [Required]
        public string SpeakerId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Topic Topic { get; set; }

        [Required]
        public byte TopicId { get; set; }

    }
}