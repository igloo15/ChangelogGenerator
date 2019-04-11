using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    /// <summary>
    /// Filter Settings allow you to define what to match on in git commit messages
    /// </summary>
    public class FilterSettings
    {
        /// <summary>
        /// Construct the FilterSettings with an initial set of keys
        /// </summary>
        /// <param name="keys"></param>
        public FilterSettings(params string[] keys)
        {
            if (keys.Length > 0)
                Keys = keys.ToList();
        }

        /// <summary>
        /// The keys to match on
        /// </summary>
        public List<string> Keys { get; set; } = new List<string>();

        /// <summary>
        /// Tokens to remove from the git commit messages to create a clean token/message
        /// </summary>
        public List<string> RemoveTokens { get; set; } = new List<string>();

        /// <summary>
        /// Remove the matched key
        /// </summary>
        public bool RemoveAllKey { get; set; } = true;

        /// <summary>
        /// Match Key Case when attempting matching
        /// </summary>
        public bool MatchCase { get; set; } = false;
    }
}
