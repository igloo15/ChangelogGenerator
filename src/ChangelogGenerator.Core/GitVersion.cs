using ChangelogGenerator.Core.Settings;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitVersion
    {
        public List<GitCommit> Commits { get; set; } = new List<GitCommit>();

        public List<GitChangelogCategory> Categories { get; set; } = new List<GitChangelogCategory>();

        public string Name { get; set; } = "";

        public GitVersion(string name, List<GitCommit> commits, List<GitChangelogCategory> categories)
        {
            Commits = commits;
            Categories = categories;
            Name = name;
        }

        public string GetText(ChangelogSettings settings)
        {
            var template = settings.Templates.VersionTemplate;

            template = template.Replace("{Version}", Name);

            return template;
        }

    }
}
