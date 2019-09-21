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

namespace fr.mougnibas.medialibrarydatabase.console
{
    /// <summary>
    /// Application generic options.
    /// </summary>
    class GenericOptions
    {
        /// <summary>
        /// Verbose mode.
        /// </summary>
        [Option('v', "verbose", Default = false, HelpText = "Enable verbose mode")]
        public bool Verbose { get; set; }

        /// <summary>
        /// Proxy mode.
        /// </summary>
        [Option(
            Default = false,
            HelpText = "Enable proxy (--proxy=socks://hostname:port)")]
        public string Proxy { get; set; }
    }
}
