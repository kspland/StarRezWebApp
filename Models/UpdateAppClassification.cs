using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateAppClassification
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }

        public int ClassificationID { get; set; }
        public string ClassificationDescripton { get; set; }
        public string TermDescription { get; set; }

        public string Status { get; set; }
    }
}