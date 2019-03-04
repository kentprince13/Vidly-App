using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_App.Models
{
    public class Rentals
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Movies Movies { get; set; }
        public int MoviesId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}