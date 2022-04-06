using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class SearchViewModel : SearchOmdbDto
    {
        SearchedMovieOmdbDto FakeMovieForNoSearchResult { get; set; } = new SearchedMovieOmdbDto();

        #region Constructors
        public SearchViewModel(SearchOmdbDto searchResultMovieList)
        {
            IsMovieListNull(searchResultMovieList);      
            this.Search = searchResultMovieList.Search.ToList();

        }
        public SearchViewModel()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Lägger till ett objekt om sökningen är null för att visa en tom sida
        /// </summary>
        /// <param name="searchResultMovieList"></param>
        /// <param name="searchedmovie"></param>
        private void IsMovieListNull(SearchOmdbDto searchResultMovieList)
        {
            if (searchResultMovieList.Search == null)
            {
                searchResultMovieList.Search = new List<SearchedMovieOmdbDto>();
                FakeMovieForNoSearchResult.imdbID = "";
                FakeMovieForNoSearchResult.Poster = "";
                FakeMovieForNoSearchResult.Title = "";
                searchResultMovieList.Search.Add(FakeMovieForNoSearchResult);
            }
        } 
        #endregion

    }
}
