using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateAppOnEntry
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }
       


        public string Term { get; set; }

        public string ApplicationStatus { get; set; }

        public string Status { get; set; }
    }
}