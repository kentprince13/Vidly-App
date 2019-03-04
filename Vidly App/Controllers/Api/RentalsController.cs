using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_App.DTOs;
using Vidly_App.Models;

namespace Vidly_App.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

 
        public IHttpActionResult Get(RentalsDto rentalsDto)
        {
            return Ok();
        }

        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IHttpActionResult Post(RentalsDto rentalsDto)
        {
            var customer = _context.Customer.Single(c => c.Id == rentalsDto.CustomerId);
            var movies = _context.Movies.Where(c => rentalsDto.MoviesId.Contains(c.Id)).ToList();
            if (customer == null && movies == null)
                return NotFound();

            foreach (var movie in movies)
            {
                if (movie.NumbersAvailable == 0)
                    return BadRequest("Movie Not Available");

                movie.NumbersAvailable--;
                var rent = new Rentals
                {
                    DateRented = DateTime.Now,
                    Customer = customer,
                    Movies = movie,
                };
                _context.Rentals.Add(rent);
            }
            _context.SaveChanges();
        
         
            return Ok();
        }

        
        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
