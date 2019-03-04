using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_App.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public bool IsSubcribed { get; set; }
        public int MembershipTypeId { get; set; }
        public MembershipDto membershipType { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}