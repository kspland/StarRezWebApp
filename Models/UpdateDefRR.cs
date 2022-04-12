using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class UpdateDefRR
    {
        public string Building { get; set; }

        public int RoomSpaceID { get; set; }

        public string RoomSpaceDescription { get; set; }

        public string RoomType { get; set; }

        public string DefaultRoomCode { get; set; }

        public string DefaultRoomRate { get; set; }


        public string  Status { get; set; }

    }
}