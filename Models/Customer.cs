using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VenMovie.Models
{
    public class Customer
    {
        [Display(Name ="Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public  string Name { get; set; }
        public  bool IsSubscribedToNewLetter { get; set; }
        [Display(Name ="Membership Type")]
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}