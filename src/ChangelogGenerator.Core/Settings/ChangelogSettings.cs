using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    public class ChangelogSettings
    {
        public List<ChangelogCategory> Categories { get; set; } = new List<ChangelogCategory>();

        public List<ChangelogLink> Links { get; set; } = new List<ChangelogLink>();

        public List<string> VersionFilters { get; set; } = new List<string>();

        public ChangelogTemplateSettings Templates { get; set; } = new ChangelogTemplateSettings();

        public string ChangelogLocation { get; set; } = "./CHANGELOG.md";

        public string GitRepoLocation { get; set; } = ".";

        public string UnreleasedTitle { get; set; } = "Unreleased";

        public int GitRepoCommitLimit { get; set; } = -1;

        public bool AllCommits { get; set; } = true;

        public bool TestMode { get; set; } = false;

        public string LatestCodeBranch { get; set; } = "develop";
    }
}
