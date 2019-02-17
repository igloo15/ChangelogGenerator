using ChangelogGenerator.Core;
using System;

namespace ChangelogGenerator.Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangelogCore core = new ChangelogCore();

            core.GenerateChangelog(args);
        }
    }
}
