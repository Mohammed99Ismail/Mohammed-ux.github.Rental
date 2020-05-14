using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenMovie.Models
{
    public class MembershipType
    {
        public string Name { get; set; }
        public byte Id { get; set; }
        public byte DiscountRate { get; set; }
        public byte DurationInMonth { get; set; }
        public short SignUpFee { get; set; }
    }
}