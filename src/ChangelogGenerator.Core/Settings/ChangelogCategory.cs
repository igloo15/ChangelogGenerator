using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    public class ChangelogCategory
    {
        public List<string> Keys { get; set; } = new List<string>();

        public List<string> ReplaceTokens { get; set; } = new List<string>();

        public bool ReplaceKey { get; set; } = true;

        public bool IsSummary { get; set; } = false;

        public bool IsDefault { get; set; } = false;

        public string DisplayName { get; set; } = "";
    }
}
