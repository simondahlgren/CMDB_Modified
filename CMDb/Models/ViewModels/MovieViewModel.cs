﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class MovieViewModel : TopMoviePropertiesOmdbDto
    {
        #region List
        private List<TopMoviesPropertiesCmdbDto> topMoviesCmdb;
        #endregion

        #region Properties
        public TopMoviePropertiesOmdbDto MovieDetails { get; set; }
        public string id { get; set; }
        #endregion

        #region Constructors
        public MovieViewModel(IEnumerable<TopMoviesPropertiesCmdbDto> topmoviescmdb, TopMoviePropertiesOmdbDto moviedetails, string id)
        {
            this.topMoviesCmdb = topmoviescmdb.ToList();
            this.MovieDetails = moviedetails;
            this.id = id;
            this.Title = moviedetails.Title;
            this.Actors = moviedetails.Actors;
            this.Poster = moviedetails.Poster;
            this.Plot = moviedetails.Plot;
            this.Poster = moviedetails.Poster;
            this.Metascore = moviedetails.Metascore;
            this.ImdbRating = moviedetails.ImdbRating;
            this.Year = moviedetails.Year;
            this.Released = moviedetails.Released;
            this.Runtime = moviedetails.Runtime;
            this.Genre = moviedetails.Genre;
            this.Director = moviedetails.Director;
            this.Writer = moviedetails.Writer;
            this.Country = moviedetails.Country;
            this.Awards = moviedetails.Awards;
            GetLikesAndDislikesForMovie();
        }
        public MovieViewModel()
        {

        } 
        #endregion

        #region Methods
        /// <summary>
        /// Hämtar Likes och Dislikes från en film
        /// </summary>
        public void GetLikesAndDislikesForMovie()
        {
            for (int i = 0; i < topMoviesCmdb.Count; i++)
            {
                if (topMoviesCmdb[i].ImdbID == id)
                {
                    this.NumberOfLikes = topMoviesCmdb[i].NumberOfLikes;
                    this.NumberOfDislikes = topMoviesCmdb[i].NumberOfDislikes;
                }

            }

        } 
        #endregion

    }

}


