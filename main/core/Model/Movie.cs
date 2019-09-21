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
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace fr.mougnibas.medialibrarydatabase.core.model
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
        /// Technical instance identifier.
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Movie name.
        /// </summary>
		[Required]
        public string Name { get; set; }

        /// <summary>
        /// Movie file path.
        /// </summary>
		[Required]
        public string File { get; set; }

        /// <summary>
        /// Movie release date.
        /// </summary>
		[Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Initialize a movie.
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <param name="file">Movie file path</param>
        /// <param name="date">Movie release date (yyyy-MM-dd format)</param>
        public Movie(string name, string file, string date)
        {
            // Direct reference
            Name = name;
            File = file;

            // Try to parse date string
            try
            {
                Date = DateTime.ParseExact(date, DATE_FORMAT, CULTURE);
            }
            catch (FormatException ex)
            {
                string message = String.Format(
                    "'{0}' is not a known format ('{1}')",
                    date, DATE_FORMAT);
                throw new FormatException(message, ex);
            }

            // Make a string "name (yyyy-MM-dd)" and checksum it to make this ID
            string unicodeClearId = String.Format("{0} ({1})", Name, date, DATE_FORMAT);
            byte[] unicodeClearIdBytes = Encoding.Unicode.GetBytes(unicodeClearId);
            byte[] unicodeChecksumIdBytes;
            using (var sha512 = new SHA512Managed())
            {
                unicodeChecksumIdBytes = sha512.ComputeHash(unicodeClearIdBytes);
            }
            Id = Convert.ToBase64String(unicodeChecksumIdBytes);
        }

        [Obsolete("This constructor is only intented for Entity Framework Core")]
        public Movie() { }

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
