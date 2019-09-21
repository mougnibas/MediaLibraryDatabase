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

using Microsoft.EntityFrameworkCore;

namespace fr.mougnibas.medialibrarydatabase.core
{
    /// <summary>
    /// A database abstraction, with media.
    /// </summary>
    public class MediaLibraryDbContext : DbContext
    {

        /// <summary>
        /// Movies set.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Default no-arg constructor.
        /// </summary>
        public MediaLibraryDbContext()
        { }

        /// <summary>
        /// Constructor allowing custom configuration, mainly used by test framework.
        /// </summary>
        /// <param name="options">Custom configuration</param>
        public MediaLibraryDbContext(DbContextOptions<MediaLibraryDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If the configuration isn't done yet, use the default one.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=MediaLibrary.db");
            }
        }
    }
}
