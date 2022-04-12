using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class Pins
    {
        public int EntryID { get; set; }
        public string PreviousPin { get; set; }
        public  string NewPin {get;set;}

        public string Status { get; set; }


    }
}