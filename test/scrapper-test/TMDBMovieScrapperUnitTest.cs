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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace fr.mougnibas.medialibrarydatabase.scrapper.test
{
    /// <summary>
    /// Unit tests of "TMDBMovieScrapper" class.
    /// </summary>
    [TestClass]
    public class TMDBMovieScrapperUnitTest
    {
        /// <summary>
        /// TMDB Movie Scrapper instance to test.
        /// </summary>
        private TMDBMovieScrapper _toTest;

        /// <summary>
        /// Initialize the movie.
        /// This method will run before each TestMethod.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            // Instantiate the scrapper to test
            _toTest = new TMDBMovieScrapper();
        }

        [TestMethod]
        public void TestScrapMatrixIdentifier()
        {
            string expected = "603";
            string actual = _toTest.Scrap("The Matrix", 1999).Id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestScrapMatrixName()
        {
            string expected = "The Matrix";
            string actual = _toTest.Scrap("The Matrix", 1999).Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestScrapMatrixDate()
        {
            DateTime expected = new DateTime(year: 1999, month: 03, day: 30, hour: 0, minute: 0, second: 0);
            DateTime actual = _toTest.Scrap("The Matrix", 1999).Date;
            Assert.AreEqual(expected, actual);
        }
    }
}
