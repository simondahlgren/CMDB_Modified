﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models
{
    public class TopMoviePropertiesOmdbDto
    {

        #region Properties
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public string Poster { get; set; }
        public string About { get; set; }
        public string Metascore { get; set; }
        public string ImdbRating { get; set; }
        public string Year { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string ImdbID { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; } 
        #endregion

    }
}
