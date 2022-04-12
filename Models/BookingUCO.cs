using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class BookingUCO
    {
        public int EntryID { get; set; }

        public string RoomSpace { get; set; }
        public int BookingID { get; set; }
       
        public string CheckOut { get; set; }

        public string Status { get; set; }
    }
}