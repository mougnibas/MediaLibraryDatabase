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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fr.mougnibas.medialibrarydatabase.core.model;

namespace fr.mougnibas.medialibrarydatabase.core.test
{
    /// <summary>
    /// Unit tests of "MediaSource" class.
    /// </summary>
    [TestClass]
    public class MediaSourceUnitTest {

        [TestMethod]
        public void TestName()
        {
            string expected = "Kids movies";
            string actual = new MediaSource("Kids movies", @"Z:\Movies\Kids", MediaSource.SourceType.MOVIE).Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPath()
        {
            string expected = @"Z:\Movies\Kids";
            string actual = new MediaSource("Kids movies", @"Z:\Movies\Kids", MediaSource.SourceType.MOVIE).Path;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestType()
        {
            MediaSource.SourceType expected = MediaSource.SourceType.MOVIE;
            MediaSource.SourceType actual = new MediaSource("Kids movies", @"Z:\Movies\Kids", MediaSource.SourceType.MOVIE).Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString()
        {
            string expected = @"MediaSource(Name=Kids movies, Path=Z:\Movies\Kids, Type=MOVIE)";
            string actual = new MediaSource("Kids movies", @"Z:\Movies\Kids", MediaSource.SourceType.MOVIE).ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
