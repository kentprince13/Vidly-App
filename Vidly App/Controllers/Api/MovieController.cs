using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly_App.DTOs;
using Vidly_App.Models;

namespace Vidly_App.Controllers
{
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/Customers
        public IHttpActionResult GetMovies(string query = null)
        {
            var movies = _context.Movies.Include(m => m.Genre).Where(c=>c.NumbersAvailable>0);
            if (!string.IsNullOrWhiteSpace(query))
            {
                movies = movies.Where(c => c.MovieTitle.Contains(query));
            };
            var moviesquery=movies
                .ToList().Select(Mapper.Map<Movies, MoviesDto>);
            return Ok(moviesquery);
        }

        // GET: api/Customers/5
        public IHttpActionResult GetMovie(int id)
        {
            
            var user = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            if (user == null)
                return NotFound();
            return Ok(Mapper.Map<Movies, MoviesDto>(user));
        }

        // POST: api/Customers
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviedto)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var Movies = Mapper.Map<MoviesDto, Movies>(moviedto);
            _context.Movies.Add(Movies);
            _context.SaveChanges();

            moviedto.Id = Movies.Id;
            return Created(new Uri(Request.RequestUri + "/" + moviedto.Id), moviedto);
        }

        // PUT: api/Customers/5
        [HttpPut]
        public IHttpActionResult PutMovie(int id, MoviesDto moviedto)
        {
            var Movies = _context.Movies.Single(c => c.Id == id);
            if (Movies == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Mapper.Map(moviedto, Movies);

            _context.SaveChanges();


            return Ok(moviedto);

        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var Movies = _context.Movies.Single(c => c.Id == id);
            if (Movies == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Remove(Movies);
            _context.SaveChanges();
            return Ok();

        }
    }
}
