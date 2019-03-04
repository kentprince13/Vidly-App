using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_App.DTOs
{
    public class MembershipDto
    {
        public int Id { get; set; }
        public string SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
        public string Name { get; set; }
    }
}