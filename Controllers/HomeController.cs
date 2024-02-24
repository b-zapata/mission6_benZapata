using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission6_benZapata.Models;
using System.Diagnostics;

namespace mission6_benZapata.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        private AddMovieContext _context;

        public HomeController(AddMovieContext temp)
        {
            _context = temp;
            //_logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            Movie newMovie = new Movie();
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View(newMovie);
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("MovieAddedConfirmation", response);
        }
        public IActionResult SeeMovies()
        {
            //Linq
            var movies = _context.Movies
                .OrderBy(x => x.MovieId)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult EditMovie(int MovieId)
        {
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == MovieId);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View("AddMovie", movieToEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("SeeMovies");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int MovieId)
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == MovieId);
            return View("ConfirmDelete", movieToDelete);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movieToDelete)
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("SeeMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
