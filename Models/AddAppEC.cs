using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class AddAppEC
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }
        public int EnrollmentClass { get; set; }
        public string Classification { get; set; }

        public string Status { get; set; }
    }
}