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
using CommandLine;
using fr.mougnibas.medialibrarydatabase.core.model;

namespace fr.mougnibas.medialibrarydatabase.console
{
    /// <summary>
    /// Main program with entry point method.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Parse command line args, and call corresponding methods
            Parser.Default.ParseArguments<GenericOptions, InitOptions>(args)
                   .WithParsed<GenericOptions>(options => HandleGenericOptions(options))
                   .WithParsed<InitOptions>(options => HandleInitOptions(options))
            ;

            // TODO Do something useful here
            Console.WriteLine("Hello World!");
            Movie movie = new Movie(
                "My movie",
                @"D:\repo\Something.stuff",
                "2019-12-31");
            Console.WriteLine("New movie : " + movie);
        }

        /// <summary>
        /// Handle generic options.
        /// </summary>
        /// <param name="options">Generic options</param>
        static void HandleGenericOptions(GenericOptions options)
        {
            if (options.Verbose)
            {
                Console.WriteLine("Verbose option enabled");
            }

            if (options.Proxy != null)
            {
                Console.WriteLine("Proxy option enabled : " + options.Proxy);
            }
        }

        /// <summary>
        /// Handle Init verb options.
        /// </summary>
        /// <param name="options"></param>
        static void HandleInitOptions(InitOptions options)
        {
            Console.WriteLine("init mode enabled");
            Console.WriteLine("TV Show directory :");
            foreach (string directory in options.Tvshow)
            {
                Console.WriteLine("* {0}", directory);
            }
        }
    }
}
