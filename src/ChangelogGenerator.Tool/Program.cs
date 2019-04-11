using ChangelogGenerator.Core;
using System;

namespace ChangelogGenerator.Tool
{
    /// <summary>
    /// Command line entry for generating changelog
    /// </summary>
    static class Program
    {
        static void Main(string[] args)
        {
            ChangelogCore core = new ChangelogCore();

            core.GenerateChangelog(args);
        }
    }
}
