﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmdbWrapper.Utilities;
using Windows.Data.Json;

namespace TmdbWrapper.Movies
{
    /// <summary>
    /// Images of a movie
    /// </summary>
    public class Images : ITmdbObject
    {
        #region properties
        /// <summary>
        /// Id of the movie
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// List of backdrops
        /// </summary>
        public IList<Backdrop> Backdrops { get; set; }
        /// <summary>
        /// List of posters
        /// </summary>
        public IList<Poster> Posters { get; set; }
        #endregion

        #region interface implementations
        void ITmdbObject.ProcessJson(JsonObject jsonObject)
        {
            Id = (int)jsonObject.GetNamedValue("id").GetSafeNumber();
            Backdrops = jsonObject.GetNamedValue("backdrops").ProcessArray<Backdrop>();
            Posters = jsonObject.GetNamedValue("posters").ProcessArray<Poster>();
        }
        #endregion
    }
}
