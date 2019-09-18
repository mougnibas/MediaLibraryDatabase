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

using CommandLine;
using System.Collections.Generic;

namespace fr.mougnibas.medialibrarydatabase.console
{
    /// <summary>
    /// "Init" verb use to initialize the media library database
    /// </summary>
    [Verb("init", HelpText = "Initialiaze MediaLibrary database")]
    class InitOptions
    {
        /// <summary>
        /// TV Show paths.
        /// </summary>
        [Option(
            Required = true,
            HelpText = "TV Show directory (separate multiple directory with ':')",
            Separator = ':')]
        public IEnumerable<string> Tvshow { get; set; }
    }
}
