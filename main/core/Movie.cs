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

using System;
using System.Globalization;
using System.Text;

namespace fr.mougnibas.medialibrarydatabase.core
{
    /// <summary>
    /// An abstraction of a movie.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Date format use both to translate date string and print date.
        /// </summary>
        private static readonly string DATE_FORMAT = "yyyy-MM-dd";

        /// <summary>
        /// Use an invariant culture (string date related).
        /// </summary>
        private static readonly CultureInfo CULTURE = CultureInfo.InvariantCulture;

        /// <summary>
        /// Movie name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Movie file path.
        /// </summary>
        private readonly string _file;

        /// <summary>
        /// Movie release date.
        /// </summary>
        private readonly DateTime _date;

        /// <summary>
        /// Initialize a movie.
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <param name="file">Movie file path</param>
        /// <param name="date">Movie release date (yyyy-MM-dd format)</param>
        public Movie(string name, string file, string date)
        {
            _name = name;
            _file = file;

            try
            {
                _date = DateTime.ParseExact(date, DATE_FORMAT, CULTURE);
            }
            catch (FormatException ex)
            {
                string message = String.Format(
                    "'{0}' is not a known format ('{1}')",
                    date, DATE_FORMAT);
                throw new FormatException(message, ex);
            }
        }

        /// <summary>
        /// Get the movie name.
        /// </summary>
        public string Name
        {
            get => _name;
        }

        /// <summary>
        /// Get the movie file path.
        /// </summary>
        public string File
        {
            get => _file;
        }

        /// <summary>
        /// Get the movie release date.
        /// </summary>
        public DateTime Date
        {
            get => _date;
        }

        public override string ToString()
        {
            return new StringBuilder()
                .Append("Movie(")
                .Append($"Name={Name}, ")
                .Append($"File={File}, ")
                .Append("Date=" + Date.ToString(DATE_FORMAT, CULTURE))
                .Append(")")
                .ToString();
        }
    }
}
