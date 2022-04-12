using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class DeleteTransactions
    {
        public int EntryID { get; set; }
        public string TermSessionDescription { get; set; }

        public int TransactionID { get; set; }

        public string ChargeGroupAbbreviation { get; set; }

        public string ChargeGroupDescription { get; set; }
        public int ChargeItemID { get; set; }

        public int Amount { get; set; }

        public string ChargeItemDescription { get; set; }

        public string Status { get; set; }

    }
}