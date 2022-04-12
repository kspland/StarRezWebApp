using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class AppStatus
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }

        public int ApplicationStatus { get; set; }

        public string Status { get; set; }

    }
}