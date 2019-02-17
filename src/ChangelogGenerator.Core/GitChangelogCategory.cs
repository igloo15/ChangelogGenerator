using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitChangelogCategory
    {
        public List<GitChangelogItem> Items { get; set; }

        public string Name { get; set; }


    }
}
