using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_App.Models;

namespace Vidly_App.DTOs
{
    public class RentalsDto
    {
        public int Id { get; set; }
       // public Customer Customer { get; set; }
        public int CustomerId { get; set; }
       // public IEnumerable<Movies> Movies { get; set; }
        public IList<int> MoviesId { get; set; }
    }
}