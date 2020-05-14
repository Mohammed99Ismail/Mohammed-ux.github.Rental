using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenMovie.Models;

namespace VenMovie.ViewModel
{
    public class CustomerMember
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipType { get; set; }
    }
}