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

namespace fr.mougnibas.medialibrarydatabase.scrapper
{
    /// <summary>
    /// Movie scrapper interface.
    /// </summary>
    public interface IMovieScrapper
    {
        /// <summary>
        /// Fetch movie informations (such as name, release date, etc.).
        /// </summary>
        /// <param name="name">The movie name (ex: "Matrix")</param>
        /// <param name="name">The movie release dyear date (ex: "1999")</param>
        /// <returns>Movie informations (such as name, release date, etc.), or null if not found.</returns>
        MovieScrap Scrap(string name, int year);
    }
}
