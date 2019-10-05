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
using System.Text;

namespace fr.mougnibas.medialibrarydatabase.core.model
{
    /// <summary>
    /// An abstraction of a media source.
    /// </summary>
    public class MediaSource
    {
        /// <summary>
        /// Media source path, also used to be the instance identifier.
        /// </summary>
        [Key]
        public string Path { get; set; }

        /// <summary>
        /// Media source type.
        /// </summary>
        public SourceType Type { get; set; }

        /// <summary>
        /// Initialize a media source.
        /// </summary>
        /// <param name="path">Media source path</param>
        /// <param name="type">Media source type</param>
        public MediaSource(string path, SourceType type)
        {
            Path = path;
            Type = type;
        }

        [Obsolete("This constructor is only intented for Entity Framework Core")]
        public MediaSource() { }

        public override string ToString()
        {
            return new StringBuilder()
                .Append("MediaSource(")
                .Append($"Path={Path}, ")
                .Append($"Type={Type}")
                .Append(")")
                .ToString();
        }

        /// <summary>
        /// Media source types.
        /// </summary>
        public enum SourceType
        {
            /// <summary>
            /// A movie media source type.
            /// </summary>
            MOVIE,

            /// <summary>
            /// A TV Show media source type.
            /// </summary>
            TV_SHOW
        }
    }
}
