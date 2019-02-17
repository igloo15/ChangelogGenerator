using ChangelogGenerator.Core.Settings;
using CommandLine;
using LibGit2Sharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChangelogGenerator.Core
{
    public class ChangelogCore
    {
        public int GenerateChangelog(string[] arguments)
        {
            return Parser.Default.ParseArguments<ChangelogCommandlineSettings>(arguments)
                .MapResult(o => GenerateChangelog(o), _ => 1);
        }

        public void GenerateChangelog(ChangelogSettings settings)
        {
            GitChangelog changelog = GitChangelog.Generate(settings);

            Console.WriteLine(changelog.GetChangeLogText());
        }

        private int GenerateChangelog(ChangelogCommandlineSettings commandLineSettings)
        {
            var configLocation = string.IsNullOrEmpty(commandLineSettings.ConfigLocation) ? "./changelog.json" : commandLineSettings.ConfigLocation;

            if (commandLineSettings.MakeConfig)
            {
                ChangelogSettings newSettings = new ChangelogSettings();

                var content = JsonConvert.SerializeObject(newSettings, Formatting.Indented);

                File.WriteAllText(configLocation, content);

                return 0;
            }

            ChangelogSettings settings = JsonConvert.DeserializeObject<ChangelogSettings>(File.ReadAllText(configLocation));

            if (commandLineSettings.DoTest)
            {
                settings.TestMode = true;
            }

            if (!string.IsNullOrEmpty(commandLineSettings.NextVersion))
            {
                settings.UnreleasedTitle = commandLineSettings.NextVersion;
            }

            GenerateChangelog(settings);

            return 0;
        }
    }
}
