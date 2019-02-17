using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitCommitParser
    {

        public static List<GitChangelogItem> Parse(List<GitCommit> commits)
        {
            return Enumerable.Empty<GitChangelogItem>().ToList();
        }
    }
}
