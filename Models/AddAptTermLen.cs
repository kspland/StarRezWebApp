using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class AddAptTermLen
    {
        public int EntryID { get; set; }

        public int EntryApplicationID { get; set; }

        public int TermLength { get; set; }
        public string TermDescription { get; set; }
       
        public string Status { get; set; }


    }
}