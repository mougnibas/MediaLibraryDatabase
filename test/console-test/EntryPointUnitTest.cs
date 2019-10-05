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
using System.IO;

namespace fr.mougnibas.medialibrarydatabase.console.test
{
    /// <summary>
    /// Unit tests of "EntryPoint" class.
    /// </summary>
    [TestClass]
    public class EntryPointUnitTest
    {
        /// <summary>
        /// License header text, repeated for every commands.
        /// </summary>
        private string _licenceHeader;

        /// <summary>
        /// Usage help text.
        /// </summary>
        private string _help;

        /// <summary>
        /// Usage help init text.
        /// </summary>
        private string _helpInit;

        /// <summary>
        /// Unparsed text.
        /// </summary>
        private string _unparsed;

        /// <summary>
        /// This method will run before each TestMethod.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            SetUpLicenceHeader();
            SetUpHelp();
            SetUpHelpInit();
            SetUpUnparsed();
        }

        /// <summary>
        /// Initialize the license header.
        /// </summary>
        private void SetUpLicenceHeader()
        {
            // Initialize the license header
            using var licenceHeader = new StringWriter();
            licenceHeader.WriteLine("Copyright © 2019 Yoann MOUGNIBAS");
            licenceHeader.WriteLine();
            licenceHeader.WriteLine("MediaLibraryDatabase is free software: you can redistribute it and/or modify");
            licenceHeader.WriteLine("it under the terms of the GNU General Public License as published by");
            licenceHeader.WriteLine("the Free Software Foundation, either version 3 of the License, or");
            licenceHeader.WriteLine("(at your option) any later version.");
            licenceHeader.WriteLine();
            licenceHeader.WriteLine("MediaLibraryDatabase is distributed in the hope that it will be useful,");
            licenceHeader.WriteLine("but WITHOUT ANY WARRANTY; without even the implied warranty of");
            licenceHeader.WriteLine("MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the");
            licenceHeader.WriteLine("GNU General Public License for more details.");
            licenceHeader.WriteLine();
            licenceHeader.WriteLine("You should have received a copy of the GNU General Public License");
            licenceHeader.WriteLine("along with MediaLibraryDatabase.  If not, see <https://www.gnu.org/licenses/>.");
            licenceHeader.WriteLine();
            licenceHeader.WriteLine();

            // Reference license header member
            _licenceHeader = licenceHeader.ToString();
        }

        /// <summary>
        /// Initialize the help text.
        /// </summary>
        public void SetUpHelp()
        {
            _help = "Usage : console [init|scan] [--help]" + Environment.NewLine;
        }

        /// <summary>
        /// Initialize the help init text.
        /// </summary>
        public void SetUpHelpInit()
        {
            _helpInit = "Usage : console init --movies=pathToMoviesDirectory[:pathToAnotherMoviesDirectory] [--help]"
                + Environment.NewLine;
        }

        /// <summary>
        /// Initialize the unparsed text.
        /// </summary>
        public void SetUpUnparsed()
        {
            _unparsed = "Error : Unparsed argument" + Environment.NewLine;
        }

        [TestMethod]
        public void TestEmpty()
        {
            // Trick to read console output
            using var consoleStringWriter = new StringWriter();
            Console.SetOut(consoleStringWriter);

            // Invoke entry point
            EntryPoint.Main(new string[] { });

            // Assert
            string expected = _licenceHeader + _help;
            string actual = consoleStringWriter.ToString();
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestHelp()
        {
            // Trick to read console output
            using var consoleStringWriter = new StringWriter();
            Console.SetOut(consoleStringWriter);

            // Invoke entry point
            EntryPoint.Main(new string[] { "--help" });

            // Assert
            string expected = _licenceHeader + _help;
            string actual = consoleStringWriter.ToString();
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestHelpInit()
        {
            // Trick to read console output
            using var consoleStringWriter = new StringWriter();
            Console.SetOut(consoleStringWriter);

            // Invoke entry point
            EntryPoint.Main(new string[] { "init", "--help" });

            // Assert
            string expected = _licenceHeader + _helpInit;
            string actual = consoleStringWriter.ToString();
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestUnparsedArg()
        {
            // Trick to read console output
            using var consoleStringWriter = new StringWriter();
            Console.SetOut(consoleStringWriter);

            // Invoke entry point
            EntryPoint.Main(new string[] { "--the", "--cake", "--is", "--a", "lie" });

            // Assert
            string expected = _licenceHeader + _unparsed + _help;
            string actual = consoleStringWriter.ToString();
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestInitUnparsedArg()
        {
            // Trick to read console output
            using var consoleStringWriter = new StringWriter();
            Console.SetOut(consoleStringWriter);

            // Invoke entry point
            EntryPoint.Main(new string[] {"init", "--the", "--cake", "--is", "--a", "lie" });

            // Assert
            string expected = _licenceHeader + _unparsed + _helpInit;
            string actual = consoleStringWriter.ToString();
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestInit()
        {
            Assert.Fail("Write me");
        }
    }
}
