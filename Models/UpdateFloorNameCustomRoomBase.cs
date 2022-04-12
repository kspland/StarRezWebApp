using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateFloorNameCustomRoomBase
    {
        public string Building { get; set; }

        public int RoomBaseID { get; set; }

        public string RoomName { get; set; }
        public string FloorName { get; set; }

        public string Status { get; set; }
    }
}