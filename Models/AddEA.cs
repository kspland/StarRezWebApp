using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class AddEA
    {
        public int EntryID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string LSUID { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public String Assignment { get; set; }

        public int TermID { get; set; }

        public int RateID { get; set; }


        public int RoomSpaceID { get; set; }

        public int RoomTypeID { get; set; }
        public int RoomLocationID { get; set; }

        public DateTime ActualCheckIn { get; set; }
        public int BookingID { get; set; }

        public string Status { get; set; }
    }
}