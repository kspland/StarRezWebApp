using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateBookingCODate
    {
        
        public int EntryID { get; set; }

        public int BookingID { get; set; }

        public string NewCheckOutDate { get; set; }

        public string Building { get; set; }
        public string RoomSpace { get; set; }


        public string Status { get; set; }


    }
}