using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly_App.Models;
using Vidly_App.Models.ViewModels;

namespace Vidly_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // without using dataTable
        //public ActionResult Index()
        //{
        //    var movies = _context.Movies.Include(c => c.Genre).ToList();

        //    return View(movies);
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Create()
        {
            var vm = new NewMovieFormViewModel
            {
                Genre = _context.Genres.ToList()
            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(NewMovieFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var vm = new NewMovieFormViewModel
                {
                    Genre = _context.Genres.ToList()
                };
                return View("create", vm);
            }

            if (viewModel.Id <= 0)
            {
                
                var movies = new Movies
                {
                    DateAdded = viewModel.DateAdded,
                    DateReleased = viewModel.DateReleased,
                    GenreId = viewModel.GenreId,
                    MovieTitle = viewModel.MovieTitle,
                    NumbersInStock = viewModel.NumbersInStock
                   
                };
                _context.Movies.Add(movies);
                _context.SaveChanges();
            }
            else
            {
                var edit = _context.Movies.Single(c => c.Id == viewModel.Id);
                edit.NumbersInStock = viewModel.NumbersInStock;
                edit.DateAdded = viewModel.DateAdded;
                edit.DateReleased = viewModel.DateReleased;
                edit.GenreId = viewModel.GenreId;
                edit.MovieTitle = viewModel.MovieTitle;
                
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            };
            var vm = new NewMovieFormViewModel
            {
                Genre = _context.Genres.ToList(),
                GenreId = movie.GenreId,
                DateAdded = movie.DateAdded,
                MovieTitle = movie.MovieTitle,
                DateReleased = movie.DateReleased,
                NumbersInStock = movie.NumbersInStock
               
            };

            return View("create", vm);
        }
    }

}