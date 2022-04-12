using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RL.Models
{
    public class CreateCI
    {
        public int ChargeGroupID { get; set; }
  
        public string ChargeGroup { get; set; }

        public string ChargeGroupAbbreviation { get; set; }


        public string ChargeItem { get; set; }

     
        public string  TISCodeConversion { get; set; }

        public string ChargeItemAbbreviation  { get; set; }

        public string  GLSAcctCode { get; set; }

        public string Objectcode { get; set; }

        public decimal DefaultAmount { get; set; }

        public string Status { get; set; }

    }
}