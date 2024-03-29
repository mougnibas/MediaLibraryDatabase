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

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fr.mougnibas.medialibrarydatabase.core.test
{
    /// <summary>
    /// Integration tests of "MediaLibraryService" class.
    /// </summary>
    [TestClass]
    public class MediaLibraryServiceIntegrationTest
    {
        /// <summary>
        /// Database connection.
        /// </summary>
        private static SqliteConnection _connection;

        /// <summary>
        /// Class instance to test.
        /// </summary>
        private MediaLibraryService _toTest;

        /// <summary>
        /// This method will run at class load.
        /// </summary>
        [ClassInitialize]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static void ClassSetup(TestContext testContext)
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

            // Instantiate the class to test
            var service = new MediaLibraryService(context);

            // Create the schema in the database
            context.Database.EnsureCreated();

            // Add a movie
            service.Add(
                new Movie(
                    "My movie",
                    @"D:\repo\Something.stuff",
                    "2019-12-31")
            );

            // Add another movie
            service.Add(
                new Movie(
                    "My movie 2",
                    @"D:\repo\Something2.stuff",
                    "2020-12-31")
            );
        }

        /// <summary>
        /// This method will run after all TestMethod have run.
        /// </summary>
        [ClassCleanup]
        public static void ClassTearDown()
        {
            _connection.Close();
        }

        /// <summary>
        /// This method will run before each TestMethod.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            // Custom options passed to DbContext
            var options = new DbContextOptionsBuilder<MediaLibraryDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Instantiate the custom context
            var context = new MediaLibraryDbContext(options);

            // Instantiate the class to test
            _toTest = new MediaLibraryService(context);
        }

        [TestMethod]
        public void TestCountMovies()
        {
            int expected = 2;
            int actual = _toTest.SearchMovies("My movie").Length;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFoundMovieByName1()
        {
            string expected = "My movie";
            string actual = _toTest.GetMovie("My movie").Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFoundMovieByName2()
        {
            string expected = "My movie 2";
            string actual = _toTest.GetMovie("My movie 2").Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFoundNothing()
        {
            Assert.IsNull(_toTest.GetMovie("Something"));
        }
    }
}
