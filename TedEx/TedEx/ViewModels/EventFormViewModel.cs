using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TedEx.Models;

namespace TedEx.ViewModels
{
    public class EventFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDateCustomValidation]
        public string Date { get; set; }

        [Required]
        [ValidTimeCustomValidation]
        public string Time { get; set; }

        [Required]
        public byte Topic { get; set; }

        [Required]
        public IEnumerable<Topic> Topics { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(String.Format("{0} {1}", Date, Time));
        }
    }
}
