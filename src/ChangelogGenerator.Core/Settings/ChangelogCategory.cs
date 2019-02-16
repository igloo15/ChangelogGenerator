using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    public class ChangelogCategory
    {
        public List<string> Keys { get; set; } = new List<string>();

        public bool IsSummaryMessage { get; set; } = false;

        public bool IsDefault { get; set; } = false;

        public string DisplayName { get; set; } = "";
    }
}
