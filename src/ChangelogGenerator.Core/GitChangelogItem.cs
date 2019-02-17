using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitChangelogItem
    {
        public string Message { get; set; }

        public GitCommit Commit { get; set; }

        public string Category { get; set; }
        
        public string Links { get; set; }
    }
}
