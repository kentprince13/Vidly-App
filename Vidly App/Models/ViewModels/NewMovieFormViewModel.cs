using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_App.Models.ViewModels
{
    public class NewMovieFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string MovieTitle { get; set; }
        [Required]
        public int NumbersInStock { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        public DateTime DateReleased { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
        public int GenreId { get; set; }
        public string Heading
        {
            get
            {
                if (Id == 0) { return "New Movie"; }
                return "Edit Movie";
            }
        }
    }
}