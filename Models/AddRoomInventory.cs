using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class AddRoomInventory
    {
        int RoomSpaceId { get; set; }

        string RoomSpaceDescription { get; set; }

        int RoomSpaceInventoryTypeID { get; set; }

        string Description { get; set; }

        int RoomSpaceInventoryConditionID { get; set; }

        string Status { get; set; }
    }
}