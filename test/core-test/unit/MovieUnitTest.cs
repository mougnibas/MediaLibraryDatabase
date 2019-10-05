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

using fr.mougnibas.medialibrarydatabase.core.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace fr.mougnibas.medialibrarydatabase.core.test.unit
{
    /// <summary>
    /// Unit tests of "Movie" class.
    /// </summary>
    [TestClass]
    public class MovieUnitTest
    {
        /// <summary>
        /// Movie class instance to test.
        /// </summary>
        private Movie _movie;

        /// <summary>
        /// Initialize the movie.
        /// This method will run before each TestMethod.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            // Instantiate a movie to test
            _movie = new Movie(
                "My movie",
                @"D:\repo\Something.stuff",
                "2019-12-31");
        }

        [TestMethod]
        public void TestNameAreEqual()
        {
            string expected = "My movie";
            string actual = _movie.Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNameAreNotEqual()
        {
            string expected = "My movieeee";
            string actual = _movie.Name;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestFileAreEqual()
        {
            string expected = @"D:\repo\Something.stuff";
            string actual = _movie.File;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFileAreNotEqual()
        {
            string expected = @"D:\repo\Something.stuffffff";
            string actual = _movie.File;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateAreEqual()
        {
            DateTime expected = new DateTime(2019, 12, 31);
            DateTime actual = _movie.Date;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDateAreNotEqual()
        {
            DateTime expected = new DateTime(2019, 12, 30);
            DateTime actual = _movie.Date;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestBadDateThrowException()
        {
            new Movie(
                "My movie",
                @"D:\repo\Something.stuff",
                "2019-12-3111");
            Assert.Fail("An exception must be thrown before this.");
        }

        [TestMethod]
        public void TestBadDateThrowExceptionWithGoodMessage()
        {
            try
            {
                new Movie(
                    "My movie",
                    @"D:\repo\Something.stuff",
                    "2019-12-3111");
                Assert.Fail("An exception must be thrown before this.");
            }
            catch (FormatException ex)
            {

                string expected = "'2019-12-3111' is not a known format ('yyyy-MM-dd')";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestGoodDateDate()
        {
            var movie = new Movie(
                    "My movie",
                    @"D:\repo\Something.stuff",
                    "2019-01-01");

            DateTime expected = new DateTime(2019, 1, 1);
            DateTime actual = movie.Date;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestId()
        {
            string expected = "J8UqrLO2vKgGg5SgHAAYl6L/yDCbxewBJ7hqQt4dJrIj18S62tHo5qKKkpYJL3hfuFvcYPrgdNZj6QAiDLnd7Q==";
            string actual = _movie.Id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString()
        {
            string expected = @"Movie(Name=My movie, File=D:\repo\Something.stuff, Date=2019-12-31)";
            string actual = _movie.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
