using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core.Settings
{
    public class ChangelogLink
    {
        public List<string> Keys { get; set; } = new List<string>();

        public List<string> ReplaceTokens { get; set; } = new List<string>();

        public string UrlTemplate { get; set; } = "";
    }
}
