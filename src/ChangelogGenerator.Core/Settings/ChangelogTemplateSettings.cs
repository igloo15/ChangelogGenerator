using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    /// <summary>
    /// The Changelog Template determines how the Changelog will look
    /// </summary>
    public class ChangelogTemplateSettings
    {
        /// <summary>
        /// The top title of the changelog
        /// </summary>
        public string TitleTemplate { get; set; } = "# Changelog";

        /// <summary>
        /// The title of each version and the unreleased
        /// </summary>
        public string VersionTemplate { get; set; } = "## {Version}";

        /// <summary>
        /// How each git commit message that is part of summary should be formatted
        /// </summary>
        public string SummarySentenceTemplate { get; set; } = "{Message}. ";

        /// <summary>
        /// How each category title in a version should be formatted
        /// </summary>
        public string CategoryTemplate { get; set; } = "### {Category}";

        /// <summary>
        /// How each line item in a category should be formatted
        /// </summary>
        public string IssueTemplate { get; set; } = "* {Message} {Links}";

        /// <summary>
        /// How links should be formatted
        /// </summary>
        public string LinkTemplate { get; set; } = "[{LinkCleanKey}]({Url})";

        /// <summary>
        /// What to write if no items in a specific category or version
        /// </summary>
        public string NoIssuesTemplate { get; set; } = " N/A ";

        /// <summary>
        /// What should be added at the end of a version section
        /// </summary>
        public string EndVersionTemplate { get; set; } = "\n";

        /// <summary>
        /// What should be added at the end of a category section
        /// </summary>
        public string EndCategoryTemplate { get; set; } = "\n";

        /// <summary>
        /// What should be added at the end of a changelog
        /// </summary>
        public string EndChangelogTemplate { get; set; } = "";
    }
}
