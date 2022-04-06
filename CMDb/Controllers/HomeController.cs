using CMDb.Models;
using CMDb.Models.ViewModels;
using CMDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Controllers
{
    
    public class HomeController : Controller
    {
        List<TopMoviePropertiesOmdbDto> omdbmovies = new List<TopMoviePropertiesOmdbDto>();
 
        private readonly IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var taskList = new List<Task>();
                var TopMoviesFromCmdbDb = await repository.GetTopMoviesAsync();//Hämtar toplistan från Cineasternas databas
                TopMoviesFromCmdbDb.OrderBy(topmovie => topmovie.NumberOfLikes);
                foreach (var movie in TopMoviesFromCmdbDb)
                {
                    if(taskList.Count == 25)// Vi hämtar bara in antalet nödvändiga filmer på första sidan för att minska laddningstiden plus 5 för att undvika kraschar. 
                    {
                        break;
                    }
                    taskList.Add(
                        Task.Run(
                            async () =>
                            {
                                var topOneRatedMovieOmdb = await repository.GetMovie(movie.ImdbID);//Hämtar topfilmen från Omdb
                                topOneRatedMovieOmdb.NumberOfDislikes = movie.NumberOfDislikes;
                                topOneRatedMovieOmdb.NumberOfLikes = movie.NumberOfLikes;
                                omdbmovies.Add(topOneRatedMovieOmdb);                         
                            }
                        ));
                }
                await Task.WhenAll(taskList);//Klar       
                var model = new HomeViewModel(omdbmovies);
                return View(model);//Skickar informationen
            }
            catch (System.Exception)//För felhantering
            {
                var model = new HomeViewModel();
                ModelState.AddModelError(string.Empty, "No contact with Api");
                return View(model);
                throw;

            }

        }
    }
}
