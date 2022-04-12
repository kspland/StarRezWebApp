using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class AddHType
    {
        public int EntryApplicationID { get; set; }
        public int EntryID { get; set; }
        public string HousingType { get; set; }

        public string RoomSpace { get; set; }

        public string Status { get; set; }
    }
}