using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class EntryAppTerm
    {
        public int EntryAppID { get; set; }

        public int EntryID { get; set; }

        public  int TermID { get; set; }

        public string Status { get; set; }
    }
}