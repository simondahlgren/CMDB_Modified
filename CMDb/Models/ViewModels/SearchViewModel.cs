using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class SearchViewModel : SearchOmdbDto
    {
        SearchedMovieOmdbDto fakeMovieForNoSearchResult { get; set; } = new SearchedMovieOmdbDto();

        #region Constructors
        public SearchViewModel(SearchOmdbDto searchForMovies)
        {
            CheckIfListIsNull(searchForMovies);      
            this.Search = searchForMovies.Search.ToList();

        }
        public SearchViewModel()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Lägger till ett objekt om sökningen är null
        /// </summary>
        /// <param name="searchForMovies"></param>
        /// <param name="searchedmovie"></param>
        private void CheckIfListIsNull(SearchOmdbDto searchForMovies)
        {
            if (searchForMovies.Search == null)
            {
                searchForMovies.Search = new List<SearchedMovieOmdbDto>();
                fakeMovieForNoSearchResult.imdbID = "";
                fakeMovieForNoSearchResult.Poster = "";
                fakeMovieForNoSearchResult.Title = "";
                searchForMovies.Search.Add(fakeMovieForNoSearchResult);
            }
        } 
        #endregion

    }
}
