using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class DeleteApps
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }

        public int ApplicationStatusID { get; set; }

        public string ApplicationStatusDescription { get; set; }

        public  int TermID { get; set; }

        public string TermDescription { get; set; }

        public string Status { get; set; }

    }

}