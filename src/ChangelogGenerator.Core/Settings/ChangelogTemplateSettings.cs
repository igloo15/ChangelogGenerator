using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    public class ChangelogTemplateSettings
    {
        public string VersionTemplate { get; set; } = "## {Version}";

        public string CategoryTemplate { get; set; } = "### {Category}";

        public string IssueTemplate { get; set; } = "* {Message} {LinkTemplate}";

        public string LinkTemplate { get; set; } = "[{LinkCleanKey}]({Url})";

        public string NoIssuesTemplate { get; set; } = " N/A ";
    }
}
