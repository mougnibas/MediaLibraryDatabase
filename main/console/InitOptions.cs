using CommandLine;
using System.Collections.Generic;

namespace fr.mougnibas.medialibrarydatabase.console
{
    /// <summary>
    /// Application invocation options.
    /// </summary>
    [Verb("init", HelpText = "Initialize the database")]
    public class InitOptions
    {
        /// <summary>
        /// Movies path.
        /// </summary>
        [Option(Required =true, HelpText = "Path to movie(s) directory(ies)")]
        public List<string> MoviesPath { get; set; }
    }
}
