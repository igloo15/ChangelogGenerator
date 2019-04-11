using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    /// <summary>
    /// Command line options that can be passed to the tool version of ChangelogGenerator
    /// </summary>
    public class ChangelogCommandlineSettings
    {
        /// <summary>
        /// Will create a config in the working directory
        /// </summary>
        [Option('m', "make-config", Default = false, HelpText = "Makes a changelog file in the current directory")]
        public bool MakeConfig { get; set; } = false;

        /// <summary>
        /// Alter the location of your changelog config
        /// </summary>
        [Option('c', "config", Default = "changelog.json", HelpText = "Location of the changelog file")]
        public string ConfigLocation { get; set; } = "changelog.json";

        /// <summary>
        /// Will print the changelog to console if set to test
        /// </summary>
        [Option('t', "test", Default = false, HelpText = "Used to test the creation of changelog file")]
        public bool DoTest { get; set; } = false;

        /// <summary>
        /// Change the unreleased section to the specified version passed with this argument
        /// </summary>
        [Option('n', "next-version", Default = null, HelpText = "The name of the next version to be released. This should be used when creating changelog for next version to be released.")]
        public string NextVersion { get; set; }

        /// <summary>
        /// Change the location of where the git repo you are pulling git commits from
        /// </summary>
        [Option('r', "repo-location", HelpText = "The location of the repo to generate a changelog from")]
        public string RepoLocation { get; set; }
    }
}
