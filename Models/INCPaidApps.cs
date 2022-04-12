using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class INCPaidApps
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }

        public DateTime ReceivedFeeDate { get; set; }

        public float ReceivedAmount { get; set; }

        public string ApplicationStatus { get; set; }

        public string Status { get; set; }

    }
}