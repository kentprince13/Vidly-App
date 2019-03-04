using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_App.Models.ViewModels
{
    public class NewFormViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Is Subscribed?")]
        public bool IsSubcribed { get; set; }

        //[Above18]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        [Display(Name ="Membership Types")]
        public int membershipTypesId { get; set; }
    }
}