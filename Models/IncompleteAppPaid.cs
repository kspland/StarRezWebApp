using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateDefaultRR
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }

        public string ApplicationStatus { get; set; }


        public string LSUStudentNumber { get; set; }

        public String UndergradPaymentFlag { get; set; }

        public Boolean AppFeeOnline { get; set; }

        public DateTime CompleteDate { get; set; }

        public DateTime ReceivedFeeDate { get; set; }

        public string Status { get; set; }
    }
}