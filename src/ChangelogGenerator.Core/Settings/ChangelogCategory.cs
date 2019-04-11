using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    /// <summary>
    /// A Changelog Category is a section of the changelog for a specific version
    /// </summary>
    public class ChangelogCategory
    {
        /// <summary>
        /// Filter determines if the git line in a commit message is part of this category
        /// </summary>
        public FilterSettings Filter { get; set; } = new FilterSettings();

        /// <summary>
        /// Determines if this category is part of the summary
        /// </summary>
        public bool IsSummary { get; set; } = false;

        /// <summary>
        /// Determines if this is a default category for git lines that match no filter
        /// </summary>
        public bool IsDefault { get; set; } = false;

        /// <summary>
        /// The Display name of this category
        /// </summary>
        public string DisplayName { get; set; } = "";
    }
}
