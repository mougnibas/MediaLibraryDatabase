// Copyright © 2019 Yoann MOUGNIBAS
//
// This file is part of MediaLibraryDatabase.
//
// MediaLibraryDatabase is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MediaLibraryDatabase is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MediaLibraryDatabase.  If not, see <https://www.gnu.org/licenses/>.

using Microsoft.Extensions.Configuration;
using System;
using TMDbLib.Client;

namespace fr.mougnibas.medialibrarydatabase.scrapper
{
    /// <summary>
    /// Movie scrapper implementation.
    /// </summary>
    public class TMDBMovieScrapper : IMovieScrapper
    {
        /// <summary>
        /// TMDB client library.
        /// </summary>
        private readonly TMDbClient _client;

        /// <summary>
        /// Configuration file key identifier of TMDB api key.
        /// </summary>
        private readonly string _apiKey = "tmdb.apiKey";

        /// <summary>
        /// Initialiaze the scrapper.
        /// TMDB api key will be retrieve using "tmdb.apiKey" key
        /// from UserSecretConfiguration (see README.md).
        /// </summary>
        public TMDBMovieScrapper()
        {
            // Build the configuration
            var configuration =
                new ConfigurationBuilder()
                    .AddUserSecrets<TMDBMovieScrapper>()
                    .Build();

            // Retrieve api key from configuration
            string apiKey = configuration[_apiKey];

            // Instantiate the client with an api key
            _client = new TMDbClient(apiKey);
        }

        /// <summary>
        /// Fetch movie informations (such as name, release date, etc.).
        /// </summary>
        /// <param name="name">The movie name (ex: "Matrix")</param>
        /// <param name="name">The movie release dyear date (ex: "1999")</param>
        /// <returns>Movie informations (such as name, release date, etc.), or null if not found.</returns>
        public MovieScrap Scrap(string name, int year)
        {
            // Search the movie
            var search = _client.SearchMovieAsync(name, page: 0, includeAdult: false, year).Result.Results[0];

            // Instantiate the MovieScrap to return, from SearchMovie values
            MovieScrap movie = new MovieScrap
            {
                Id = search.Id.ToString(),
                Name = search.Title,
                Date = search.ReleaseDate ?? new DateTime()
            };

            // Return the MovieScrap
            return movie;
        }
    }
}
