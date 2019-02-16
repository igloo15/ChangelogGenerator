using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    public class ChangelogSettings
    {
        public List<ChangelogCategory> Categories { get; set; } = new List<ChangelogCategory>();

        public List<string> VersionFilters { get; set; } = new List<string>();

        public string VersionTemplate { get; set; } = "## {Version}";

        public string CategoryTemplate { get; set; } = "### {Category}";

        public string IssueTemplate { get; set; } = "* {Message} {LinkTemplate}";

        public string LinkTemplate { get; set; } = "[{LinkCleanKey}]({Url})";

        public string NoIssuesTemplate { get; set; } = " N/A ";

        public string ChangelogLocation { get; set; } = "./CHANGELOG.md";

        public string GitRepoLocation { get; set; } = ".";

        public string UnreleasedTitle { get; set; } = "Unreleased";

        public int GitRepoCommitTake { get; set; } = -1;

        public bool AllCommits { get; set; } = true;
    }
}
