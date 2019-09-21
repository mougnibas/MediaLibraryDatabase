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

using System.Collections.Generic;
using System.Linq;

namespace fr.mougnibas.medialibrarydatabase.core
{
    /// <summary>
    /// Media library Database service.
    /// </summary>
    public class MediaLibraryService
    {

        /// <summary>
        /// Media Library db context.
        /// </summary>
        private readonly MediaLibraryDbContext _context;

        /// <summary>
        /// Default no-arg constructor.
        /// </summary>
        public MediaLibraryService()
        {
            _context = new MediaLibraryDbContext();
        }

        /// <summary>
        /// Constructor with DbContext.
        /// <param name="context">Custom db context</param>
        /// </summary>
        public MediaLibraryService(MediaLibraryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a movie.
        /// <param name="movie">The movie to add.</param>
        /// </summary>
        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        /// <summary>
        /// Try to find movies by name.
        /// </summary>
        /// <param name="name">Name of movies</param>
        /// <returns>The movies foun (if any)d, ordered by name.</returns>
        public Movie[] SearchMovies(string name)
        {
            return _context.Movies
               .Where(m => m.Name.Contains(name))
               .OrderBy(m => m.Name)
               .ToArray();
        }

        /// <summary>
        /// Try to find a movie by name.
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <returns>The movie, if found (or null if not found).</returns>
        public Movie GetMovie(string name)
        {
            return _context.Movies
               .Where(m => m.Name.Equals(name))
               .FirstOrDefault();
        }
    }
}
