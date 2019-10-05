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

using fr.mougnibas.medialibrarydatabase.core.service;
using System;

namespace fr.mougnibas.medialibrarydatabase.core.test.mock
{
    /// <summary>
    /// Mock implementation of Scanner Service Interface.
    /// </summary>
    public class MockScannerService : IScannerService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="path">
        /// A path to scan. May be :
        /// * "Z:\Movies\Kids"
        /// * "Z:\Movies\Parents"
        /// * "Z:\TVShows\Kids"
        /// * "Z:\TVShows\Parents"
        /// </param>
        /// <returns>
        /// If "Z:\Movies\Kids", return "Z:\Movies\Kids\Movie for kids (2019)\Movie for kids (2019).mkv"
        /// If "Z:\Movies\Parents", return "Z:\Movies\Parents\Movie for parents (2019)\Movie for parents (2019).mkv"
        /// If "Z:\TVShows\Kids", return "Z:\TVShows\Kids\TVShow for kids (2019)\Season 1\TVShow for kids (2019) - S01E01.mkv"
        /// If "Z:\TVShows\Parents", return "Z:\TVShows/Parents\TVShow for parents (2019)\Season 1\TVShow for parents (2019) - S01E01.mkv"
        /// </returns>
        public string[] Scan(string path)
        {
            if (@"Z:\Movies\Kids".Equals(path))
            {
                return new[] { @"Z:\Movies\Kids\Movie for kids (2019)\Movie for kids (2019).mkv" };
            }
            else if (@"Z:\Movies\Parents".Equals(path))
            {
                return new[] { @"Z:\Movies\Parents\Movie for parents (2019)\Movie for parents (2019).mkv" };
            }
            else if (@"Z:\TVShows\Kids".Equals(path))
            {
                return new[] { @"Z:\TVShows\Kids\TVShow for kids (2019)\Season 1\TVShow for kids (2019) - S01E01.mkv" };
            }
            else if (@"Z:\TVShows\Parents".Equals(path))
            {
                return new[] { @"Z:\TVShows\Parents\TVShow for parents (2019)\Season 1\TVShow for parents (2019) - S01E01.mkv" };
            }
            else
            {
                throw new Exception("Unkown predefined path was used");
            }
        }
    }
}
