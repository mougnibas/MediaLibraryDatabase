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

using fr.mougnibas.medialibrarydatabase.core.test.mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace fr.mougnibas.medialibrarydatabase.core.test.unit
{
    /// <summary>
    /// Unit tests of "MockScannerService" class.
    /// </summary>
    [TestClass]
    public class MockScannerServiceUnitTest
    {

        [TestMethod]
        public void TestKidsMovie()
        {
            string expected = @"Z:\Movies\Kids\Movie for kids (2019)\Movie for kids (2019).mkv";
            string actual = new MockScannerService().Scan(@"Z:\Movies\Kids")[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParentsMovie()
        {
            string expected = @"Z:\Movies\Parents\Movie for parents (2019)\Movie for parents (2019).mkv";
            string actual = new MockScannerService().Scan(@"Z:\Movies\Parents")[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKidsTvShow()
        {
            string expected = @"Z:\TVShows\Kids\TVShow for kids (2019)\Season 1\TVShow for kids (2019) - S01E01.mkv";
            string actual = new MockScannerService().Scan(@"Z:\TVShows\Kids")[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParentsTvShow()
        {
            string expected = @"Z:\TVShows\Parents\TVShow for parents (2019)\Season 1\TVShow for parents (2019) - S01E01.mkv";
            string actual = new MockScannerService().Scan(@"Z:\TVShows\Parents")[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUnknow()
        {
            new MockScannerService().Scan(@"Z:\TVShows\Unkown");
            Assert.Fail("The previous line should throw an exception.");
        }
    }
}
