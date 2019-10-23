﻿using CommandLine;

namespace fr.mougnibas.medialibrarydatabase.console
{
    /// <summary>
    /// Application invocation options.
    /// </summary>
    public class CommonOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
    }
}
