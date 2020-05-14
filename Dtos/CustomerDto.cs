using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VenMovie.Models;

namespace VenMovie.Dtos
{
    public class CustomerDto
    {
        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public MembershipDto MembershipType { get; set; }
        public bool IsSubscribedToNewLetter { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}