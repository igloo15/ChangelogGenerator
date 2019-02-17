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

            sb.AppendLine(Settings.Templates.TitleTemplate);
            foreach(var version in Versions)
            {
                sb.AppendLine(version.GetText(Settings));
                foreach(var category in version.Categories)
                {
                    sb.AppendLine(category.GetText(Settings));
                    foreach(var item in category.Items)
                    {
                        sb.AppendLine($"{item.Message}");
                    }
                    sb.AppendLine(Settings.Templates.EndCategoryTemplate);
                }
                sb.AppendLine(Settings.Templates.EndVersionTemplate);
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
