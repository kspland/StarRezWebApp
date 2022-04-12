using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class roomInventory
    {
        public int RoomSpaceID { get; set; }
        public int RoomSpaceInventory { get; set; }

        public int RoomSpaceInventoryCondition { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        public string Status { get; set; }
    }
}