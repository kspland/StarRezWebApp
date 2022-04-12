using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateBookingCIDate
    {
        public int EntryID { get; set; }

        public int BookingID { get; set; }

        public string NewCheckInDate { get; set; }

        public string Building { get; set; }
        public string RoomSpace { get; set; }



        public string Status { get; set; }
    }
}