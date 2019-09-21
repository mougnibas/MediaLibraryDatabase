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
using System.IO;
using System.Linq;
using fr.mougnibas.medialibrarydatabase.core.database;
using fr.mougnibas.medialibrarydatabase.core.model;

namespace fr.mougnibas.medialibrarydatabase.core.service
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
        /// Media scanner.
        /// </summary>
        private readonly IScannerService _scanner;

        /// <summary>
        /// Default no-arg constructor.
        /// </summary>
        public MediaLibraryService()
        {
            _context = new MediaLibraryDbContext();
            _scanner = new ScannerService();
        }

        /// <summary>
        /// Constructor with DbContext.
        /// <param name="context">Custom db context</param>
        /// <param name="scanner">Custom scanner</param>
        /// </summary>
        public MediaLibraryService(MediaLibraryDbContext context, IScannerService scanner)
        {
            _context = context;
            _scanner = scanner;
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
        /// Add a media source.
        /// </summary>
        /// <param name="mediaSource">Media source to add</param>
        public void Add(MediaSource mediaSource)
        {
            _context.MediaSources.Add(mediaSource);
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
        /// Try to get a movie by name.
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <returns>The movie, if found (or null if not found).</returns>
        public Movie GetMovie(string name)
        {
            return _context.Movies
               .Where(m => m.Name.Equals(name))
               .FirstOrDefault();
        }

        /// <summary>
        /// Get all media sources.
        /// </summary>
        /// <returns>All media sources, ordered by name</returns>
        public MediaSource[] GetMediaSources()
        {
            return _context.MediaSources.OrderBy(s => s.Name).ToArray();
        }

        /// <summary>
        /// Get a media source.
        /// </summary>
        /// <param name="name">Media source name</param>
        /// <returns>A media source, if any</returns>
        public MediaSource GetMediaSource(string name)
        {
            return _context.MediaSources
               .Where(m => m.Name.Equals(name))
               .FirstOrDefault();
        }

        /// <summary>
        /// Scan for new media.
        /// </summary>
        public void Scan()
        {
            ScanMovies();
        }

        /// <summary>
        /// Scan for new movie media.
        /// </summary>
        private void ScanMovies()
        {
            // Scan all movies media files in media sources
            var mediaFiles = new List<string>();
            foreach (MediaSource mediaSource in GetMediaSources().Where(m => m.Type.Equals(MediaSource.SourceType.MOVIE)))
            {
                // Scan movie media files from current source and add them to the global media files
                string[] currentMediaFiles = _scanner.Scan(mediaSource.Path);
                mediaFiles.AddRange(currentMediaFiles);
            }

            // For each media movie file, create (or update) the movie in the database
            foreach (string mediaFile in mediaFiles)
            {
                // Extract movie name, from directory
                string movieDirectoryName = new FileInfo(mediaFile).Directory.Name;

                // If movie is not already in the database, add it
                if (GetMovie(movieDirectoryName) == null)
                {
                    // Extract date from movie directory
                    int startIndex = movieDirectoryName.IndexOf('(');
                    int endIndex = movieDirectoryName.IndexOf(')');
                    string date = movieDirectoryName.Substring(startIndex, endIndex);

                    // Extract name from movie directory
                    string name = movieDirectoryName.Substring(0, startIndex);

                    // Create the movie
                    Movie movie = new Movie(name, mediaFile, date);

                    // Add it to the database
                    Add(movie);
                }
            }
        }
    }
}
