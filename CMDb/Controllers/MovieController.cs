using CMDb.Models;
using CMDb.Models.ViewModels;
using CMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepository repository;
        public MovieController(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region HttpGet
        [HttpGet]
        public async Task<IActionResult> GetMovie(string id)
        {

            try
            {
                var topRatedMoviesCmdb = repository.GetTopMoviesAsync();
                var choosenMovie = repository.GetMovie(id);

                await Task.WhenAll(topRatedMoviesCmdb, choosenMovie);//Klar

                var topMovies = await topRatedMoviesCmdb;
                var movie = await choosenMovie;

                var model = new MovieViewModel(topMovies, movie, id);
                return View("index", model);//Skickar informationen

            }
            catch (System.Exception)//För felhantering
            {
                var model = new MovieViewModel();
                ModelState.AddModelError(string.Empty, "No contact with Api");
                return View(model);
                throw;
            }
        } 
        #endregion
    }
}
