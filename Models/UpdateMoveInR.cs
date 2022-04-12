using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateMoveInR
    {
        public string Building { get; set; }

        public int RoomSpaceID { get; set; }

        public string RoomSpace { get; set; }

        public string MoveInTime {get;set;}

        public string Status { get; set; }
    }
}