using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    /// <summary>
    /// This allows you to link to a specified place online when a git commit line matches the filter
    /// </summary>
    public class ChangelogLink
    {
        /// <summary>
        /// The filter on a git commit line that must match for the link to be produced
        /// </summary>
        public FilterSettings Filter { get; set; } = new FilterSettings();

        /// <summary>
        /// The template of the Url for this key
        /// </summary>
        public string UrlTemplate { get; set; } = "";
    }
}
