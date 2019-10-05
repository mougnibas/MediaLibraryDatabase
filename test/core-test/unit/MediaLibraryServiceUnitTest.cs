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

using fr.mougnibas.medialibrarydatabase.core.database;
using fr.mougnibas.medialibrarydatabase.core.model;
using fr.mougnibas.medialibrarydatabase.core.service;
using fr.mougnibas.medialibrarydatabase.core.test.mock;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fr.mougnibas.medialibrarydatabase.core.test.unit
{
    /// <summary>
    /// Unit tests of "MediaLibraryService" class.
    /// </summary>
    [TestClass]
    public class MediaLibraryServicetUnitTest
    {
        /// <summary>
        /// Database connection.
        /// </summary>
        private SqliteConnection _connection;

        /// <summary>
        /// Class instance to test.
        /// </summary>
        private MediaLibraryService _toTest;

        /// <summary>
        /// This method will run before each TestMethod.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            // In-memory database only exists while the connection is open
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            // Custom options passed to DbContext
            var options = new DbContextOptionsBuilder<MediaLibraryDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Instantiate the custom context
            var context = new MediaLibraryDbContext(options);

            // Instantiate the custom scanner
            var scanner = new MockScannerService();

            // Instantiate the class to test
            _toTest = new MediaLibraryService(context, scanner);

            // Create the schema in the database
            context.Database.EnsureCreated();
        }

        /// <summary>
        /// This method will run after each TestMethod.
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            _connection.Close();
        }

        [TestMethod]
        public void TestCountMovies()
        {
            int expected = 0;
            int actual = _toTest.SearchMovies("My movie").Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddAndCountMovies()
        {
            _toTest.Add(new Movie(
                "My movie",
                @"D:\repo\Something.stuff",
                "2019-12-31"));

            int expected = 1;
            int actual = _toTest.SearchMovies("My movie").Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFoundMovieByName1()
        {
            _toTest.Add(new Movie(
                "My movie",
                @"D:\repo\Something.stuff",
                "2019-12-31"));

            _toTest.Add(new Movie(
                "My movie 2",
                @"D:\repo\Something2.stuff",
                "2020-12-31"));

            string expected = "My movie";
            string actual = _toTest.GetMovie("My movie").Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFoundMovieByName2()
        {
            _toTest.Add(new Movie(
                "My movie",
                @"D:\repo\Something.stuff",
                "2019-12-31"));

            _toTest.Add(new Movie(
                "My movie 2",
                @"D:\repo\Something2.stuff",
                "2020-12-31"));

            string expected = "My movie 2";
            string actual = _toTest.GetMovie("My movie 2").Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFoundNothing()
        {
            Assert.IsNull(_toTest.GetMovie("Something"));
        }

        [TestMethod]
        public void TestMediaSourcePath()
        {
            _toTest.Add(new MediaSource(@"Z:\Movies\Kids", MediaSource.SourceType.MOVIE));

            string expected = @"Z:\Movies\Kids";
            string actual = _toTest.GetMediaSources()[0].Path;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMediaSourceType()
        {
            _toTest.Add(new MediaSource(@"Z:\Movies\Kids", MediaSource.SourceType.MOVIE));

            MediaSource.SourceType expected = MediaSource.SourceType.MOVIE;
            MediaSource.SourceType actual = _toTest.GetMediaSources()[0].Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestScan()
        {
            _toTest.Add(new MediaSource(@"Z:\Movies\Kids", MediaSource.SourceType.MOVIE));
            _toTest.Scan();

            string expected = "Movie for kids";
            string actual = _toTest.GetMovie("Movie for kids").Name;
            Assert.AreEqual(expected, actual);
        }
    }
}
