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
using CommandLine;

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
        /// "OK" return code (0).
        /// </summary>
        private static readonly int RETURN_CODE_OK = 0;

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
            Parser.Default.ParseArguments<CommonOptions, InitOptions>(args)
                .MapResult(

                (CommonOptions options) => RunAndReturnExitCode(options),
                (InitOptions options) => RunInitAndReturnExitCode(options),

                errs => 1
                );
        }

        /// <summary>
        /// Print the license, eventually the verbose mode if enabled, then return "0" code.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private static int RunAndReturnExitCode(CommonOptions options)
        {
            // Print the license
            PrintLicense();

            // If verbose mode is enabled, notify the user
            if (options.Verbose)
            {
                LOG.LogTrace("Verbose mode enabled");
            }

            // Gracefuly return
            return RETURN_CODE_OK;
        }

        /// <summary>
        /// Print the license, first initialization of the database, then return "0" code.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private static int RunInitAndReturnExitCode(InitOptions options)
        {
            // Print the license
            PrintLicense();

            // Init the database
            var service = new MediaLibraryService();
            foreach (string moviePath in options.MoviesPath)
            {
                service.Add(new MediaSource(moviePath, MediaSource.SourceType.MOVIE));
            }
            // TODO Restart here

            // Gracefuly return
            return RETURN_CODE_OK;
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
    }
}
