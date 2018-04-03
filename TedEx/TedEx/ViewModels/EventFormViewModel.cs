﻿using System;
using System.Collections.Generic;
using TedEx.Models;

namespace TedEx.ViewModels
{
    public class EventFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Topic { get; set; }
        public IEnumerable<Topic> Topics { get; set; }

        public DateTime DateTime
        {
            get
            { return DateTime.Parse(String.Format("{0} {1}", Date, Time)); }
        }
    }
}
