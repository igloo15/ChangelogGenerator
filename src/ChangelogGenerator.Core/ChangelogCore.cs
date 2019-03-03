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

        public int GenerateChangelog(ChangelogSettings settings)
        {
            var gitFolder = Path.Combine(settings.GitRepoLocation, ".git");

            if (!Directory.Exists(gitFolder))
            {
                Console.Error.WriteLine($"Could not detect .git folder in {settings.GitRepoLocation}");
                Console.Error.WriteLine($"Without a git folder the history can not be analyzed");
                return 1;
            }


            GitChangelog changelog = GitChangelog.Generate(settings);

            var content = changelog.GetChangeLogText();

            if (settings.TestMode)
            {
                Console.WriteLine(content);
            }
            else
            {
                File.WriteAllText(settings.ChangelogLocation, content);
            }

            return 0;
        }

        private int GenerateChangelog(ChangelogCommandlineSettings commandLineSettings)
        {
            var configLocation = string.IsNullOrEmpty(commandLineSettings.ConfigLocation) ? "./changelog.json" : commandLineSettings.ConfigLocation;

            if (commandLineSettings.MakeConfig)
            {
                ChangelogSettings newSettings = new ChangelogSettings();

                var directory = Path.GetDirectoryName(configLocation);
                if (string.IsNullOrEmpty(directory))
                    directory = Environment.CurrentDirectory;

                if (!Directory.Exists(directory))
                {
                    Console.Error.WriteLine($"Path {directory} does not exist");
                    return 1;
                }
                    

                var content = JsonConvert.SerializeObject(newSettings, Formatting.Indented);

                File.WriteAllText(configLocation, content);

                return 0;
            }

            if(!File.Exists(configLocation))
            {
                Console.Error.WriteLine($"Config file {configLocation} does not exist");
                Console.Error.WriteLine("Create a config file using -m or --make-config");
                return 1;
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

            if (!string.IsNullOrEmpty(commandLineSettings.RepoLocation))
            {
                settings.GitRepoLocation = commandLineSettings.RepoLocation;
            }

            return GenerateChangelog(settings);
        }
    }
}
