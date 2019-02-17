using ChangelogGenerator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitChangelogCategory
    {
        public List<GitChangelogItem> Items { get; set; }

        public string Name { get; set; }

        public string GetText(ChangelogSettings settings)
        {
            var template = settings.Templates.CategoryTemplate;

            template = template.Replace("{Category}", Name);

            return template;
        }
    }
}
