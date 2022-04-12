using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateNonActivePaidApp
    {
        public int EntryApplicationID { get; set; }

        public int EntryID { get; set; }

        public int ApplicationStatusID { get; set; }

        public string ApplicationStatusDescription { get; set; }

        public string TermDescription { get; set; }
        
        public DateTime ReceivedFeeDate { get; set; }
        public float ReceivedFeeAmount { get; set; }
        public String Status { get; set; }
    }
}