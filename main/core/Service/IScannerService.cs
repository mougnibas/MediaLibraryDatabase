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
using fr.mougnibas.medialibrarydatabase.core.database;
using fr.mougnibas.medialibrarydatabase.core.model;

namespace fr.mougnibas.medialibrarydatabase.core.service
{
    /// <summary>
    /// Scanner service interface.
    /// </summary>
    public interface IScannerService
    {
        /// <summary>
        /// Scan a directory (and sub-directories) and return all media file paths.
        /// </summary>
        /// <param name="path">The directory path to scan.</param>
        /// <returns>All media files paths.</returns>
        string[] Scan(string path);
    }
}
