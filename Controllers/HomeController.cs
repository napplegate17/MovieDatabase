//Nicholas Applegate, Section 1 Group 3

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        private MovieListContext context { get; set; }

        //Constructor
        public HomeController(MovieListContext con)
        {
            context = con;
        }

        //set up navigation for routing to views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            MovieDatabase.Models.ViewModels.MovieListViewModel model = new MovieDatabase.Models.ViewModels.MovieListViewModel(context);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditMovieForm(Movie movie, int movieId)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Update(movie);
                context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult EditMovieForm(Movie movie)
        {
            return View(movie);
        }

        //submit form and send information to the Movie List
        [HttpPost]
        public IActionResult AddMovieForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult AddMovieForm()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
