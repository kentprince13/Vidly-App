using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_App.Models
{
    public class Customer
    {
            public int Id { get; set; }

            [StringLength(100)]
            [Required]
            public string Name { get; set; }
            public bool IsSubcribed { get; set; }
            public MembershipType MembershipType { get; set; }
            public int MembershipTypeId { get; set; }
            [Display(Name ="date Of Birth")]
            public DateTime? DateOfBirth { get; set; }
           
    }
    
}