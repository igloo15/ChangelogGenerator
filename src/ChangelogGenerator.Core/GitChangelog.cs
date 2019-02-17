using ChangelogGenerator.Core.Settings;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitChangelog
    {
        public ChangelogSettings Settings { get; set; } = new ChangelogSettings();

        public List<GitVersion> Versions { get; set; } = new List<GitVersion>();

        public GitChangelog(List<GitVersion> versions, ChangelogSettings settings)
        {
            Versions = versions;
            Settings = settings;
        }

        public string GetChangeLogText()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var version in Versions)
            {
                sb.AppendLine(version.Name);
                sb.AppendLine($"Commits : {version.Commits.Count}");
                foreach(var commit in version.Commits)
                {
                    sb.AppendLine($"{commit.CommitDate} - {commit.Message}");
                }
            }


            return sb.ToString();
        }


        public static GitChangelog Generate(ChangelogSettings settings)
        {
            var versions = Utility.GetVersions(settings);

            return new GitChangelog(versions, settings);
        }
    }
}
