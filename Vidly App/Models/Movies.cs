using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_App.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieTitle { get; set; }
        [Required]
        public int NumbersInStock { get; set; }
        public int NumbersAvailable { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateReleased { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}