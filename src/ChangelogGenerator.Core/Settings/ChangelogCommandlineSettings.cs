using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    public class ChangelogCommandlineSettings
    {
        [Option('m', "make-config", Default = false, HelpText = "Makes a changelog file in the current directory")]
        public bool MakeConfig { get; set; } = false;

        [Option('c', "config", Default = "changelog.json", HelpText = "Location of the changelog file")]
        public string ConfigLocation { get; set; } = "changelog.json";

        [Option('t', "test", Default = false, HelpText = "Used to test the creation of changelog file")]
        public bool DoTest { get; set; } = false;

        [Option('n', "next-version", Default = null, HelpText = "The name of the next version to be released. This should be used when creating changelog for next version to be released.")]
        public string NextVersion { get; set; }
    }
}
