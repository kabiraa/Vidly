﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipTypes
    {
        public int Id { get; set; }
        public string MembershipName { get; set; }
        public short SignUpFee { get; set; }
        public byte DiscountRate { get; set; }
        public byte DurationInMonths { get; set; }

    }
}