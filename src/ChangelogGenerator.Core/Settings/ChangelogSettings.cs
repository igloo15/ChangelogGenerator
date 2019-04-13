using System.Collections.Generic;

namespace ChangelogGenerator.Core.Settings
{
    /// <summary>
    /// The main Changelog Config
    /// </summary>
    public class ChangelogSettings
    {
        /// <summary>
        /// Constructs a default Changelog config
        /// </summary>
        public ChangelogSettings()
        {
            Categories = new List<ChangelogCategory>
            {
                new ChangelogCategory
                {
                    Filter = new FilterSettings("#Add"),
                    DisplayName = "Add"
                },
                new ChangelogCategory
                {
                    Filter = new FilterSettings("#Changes"),
                    DisplayName = "Other Changes",
                    IsDefault = false
                },
                new ChangelogCategory
                {
                    Filter = new FilterSettings("#Summary"),
                    DisplayName = "Summary",
                    IsSummary = true
                }
            };

            Links = new List<ChangelogLink>
            {
                new ChangelogLink
                {
                    Filter = new FilterSettings("#issue")
                    {
                        RemoveTokens = new List<string>{ "#" },
                        RemoveAllKey = false
                    },
                    UrlTemplate = "https://github.com/temp_user/temp_project/issues/{LinkCleanKey}"
                }
            };
        }

        /// <summary>
        /// The categories of a specific version in a changelog
        /// </summary>
        public List<ChangelogCategory> Categories { get; set; } = new List<ChangelogCategory>();

        /// <summary>
        /// Defines links that can appear on each changelog item
        /// </summary>
        public List<ChangelogLink> Links { get; set; } = new List<ChangelogLink>();

        /// <summary>
        /// Defines what is a version from the tags
        /// </summary>
        public FilterSettings VersionFilter { get; set; } = new FilterSettings("v");

        /// <summary>
        /// Defines the templates for how the changelog should look
        /// </summary>
        public ChangelogTemplateSettings Templates { get; set; } = new ChangelogTemplateSettings();

        /// <summary>
        /// Defines the location of where the changelog should be written
        /// </summary>
        public string ChangelogLocation { get; set; } = "./CHANGELOG.md";

        /// <summary>
        /// Defines the location of the gitrepo relative to this changelog
        /// </summary>
        public string GitRepoLocation { get; set; } = ".";

        /// <summary>
        /// Defines the title of the unreleased git changelog items
        /// </summary>
        public string UnreleasedTitle { get; set; } = "Unreleased";

        /// <summary>
        /// Defines how far back the changelog should search for git commits and tags
        /// </summary>
        public int GitRepoCommitLimit { get; set; } = -1;

        /// <summary>
        /// Determines if all commits should be searched
        /// </summary>
        public bool AllCommits { get; set; } = true;

        /// <summary>
        /// Include categories that have no items
        /// </summary>
        public bool IncludeEmptyCategories { get; set; } = true;

        /// <summary>
        /// Determines if this changelog generation is running in test mode
        /// </summary>
        public bool TestMode { get; set; } = false;

        /// <summary>
        /// Determines the name of the latest code branch for use when calculating unreleased git items
        /// </summary>
        public string LatestCodeBranch { get; set; } = "develop";
    }
}
