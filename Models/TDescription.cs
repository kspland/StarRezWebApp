using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class TDescription
    {
        public int TransactionID { get; set; }
        public int EntryID { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}