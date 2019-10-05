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
using fr.mougnibas.medialibrarydatabase.core.service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace fr.mougnibas.medialibrarydatabase.console
{
    /// <summary>
    /// Main program with entry point method.
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// Class logger.
        /// </summary>
        private static readonly ILogger LOG;

        /// <summary>
        /// Configure logging.
        /// </summary>
        static EntryPoint()
        {
            // Reference :
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging

            // Configure logging
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                // TODO Use a custom formatter to avoid "level" print in console
                // Reference :  https://stackoverflow.com/questions/44230373/is-there-a-way-to-format-the-output-format-in-net-core-logging
                builder
                    .AddFilter("fr.mougnibas.medialibrarydatabase.console.EntryPoint", LogLevel.Debug)
                    .SetMinimumLevel(LogLevel.Information)
                    .AddConsole();
            });
            LOG = loggerFactory.CreateLogger<EntryPoint>();
        }

        /// <summary>
        /// Entry point method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Print License
            PrintLicense();

            // Parse arguments
            ParseArgs(args);
        }

        /// <summary>
        /// Print application license.
        /// </summary>
        private static void PrintLicense()
        {
            Console.WriteLine("Copyright © 2019 Yoann MOUGNIBAS");
            Console.WriteLine();
            Console.WriteLine("MediaLibraryDatabase is free software: you can redistribute it and/or modify");
            Console.WriteLine("it under the terms of the GNU General Public License as published by");
            Console.WriteLine("the Free Software Foundation, either version 3 of the License, or");
            Console.WriteLine("(at your option) any later version.");
            Console.WriteLine();
            Console.WriteLine("MediaLibraryDatabase is distributed in the hope that it will be useful,");
            Console.WriteLine("but WITHOUT ANY WARRANTY; without even the implied warranty of");
            Console.WriteLine("MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the");
            Console.WriteLine("GNU General Public License for more details.");
            Console.WriteLine();
            Console.WriteLine("You should have received a copy of the GNU General Public License");
            Console.WriteLine("along with MediaLibraryDatabase.  If not, see <https://www.gnu.org/licenses/>.");
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Parse entry point arguments.
        /// </summary>
        /// <param name="args">Entry point arguments</param>
        private static void ParseArgs(string[] args)
        {
            // Put args in a list
            var argsList = new List<string>(args);

            // no args ? Print help
            if (argsList.Count == 0)
            {
                PrintHelp();
            }
            // --help ?
            else if (argsList.Count == 1 && argsList.Contains("--help"))
            {
                PrintHelp();
            }
            // init ? Print init help
            else if (argsList.Count == 1 && argsList.Contains("init"))
            {
                PrintHelpInit();
            }
            // init --help ? Print init help
            else if (argsList.Count == 2 && argsList.Contains("init") && argsList.Contains("--help"))
            {
                PrintHelpInit();
            }
            // init with unparsed arg ? Print unparsed Arg and print init help
            else if (argsList.Count != 2 && argsList.Contains("init"))
            {
                PrintUnparsedArg();
                PrintHelpInit();
            }
            // init --movies /path/to/sources:/path/to/other/sources ? Do the stuff
            else if (argsList.Count == 3 && argsList.Contains("init"))
            {
                string moviesPath = argsList[2];
                string[] moviesPaths = moviesPath.Split(":");
                Init(moviesPaths);
            }
            // Unparsed arg ? Print a warning and print help
            else
            {
                PrintUnparsedArg();
                PrintHelp();
            }
        }

        /// <summary>
        /// Print help message.
        /// </summary>
        private static void PrintHelp()
        {
            Console.WriteLine("Usage : console [init|scan] [--help]");
        }

        /// <summary>
        /// Print an help message about "init" verb.
        /// </summary>
        private static void PrintHelpInit()
        {
            Console.WriteLine("Usage : console init --movies=pathToMoviesDirectory[:pathToAnotherMoviesDirectory] [--help]");
        }

        /// <summary>
        /// Print an unparsed argument message;
        /// </summary>
        private static void PrintUnparsedArg()
        {
            Console.WriteLine("Error : Unparsed argument");
        }

        /// <summary>
        /// First initialize of the database.
        /// </summary>
        /// <param name="moviesPaths">Movies paths</param>
        private static void Init(string[] moviesPaths)
        {

            var service = new MediaLibraryService();
            foreach (string moviePath in moviesPaths)
            {
                service.Add(new MediaSource(moviePath, MediaSource.SourceType.MOVIE));
            }
            
            // TODO Restart here
        }
    }
}
