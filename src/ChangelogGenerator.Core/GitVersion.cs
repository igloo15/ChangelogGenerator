using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitVersion
    {
        public List<GitCommit> Commits { get; set; } = new List<GitCommit>();

        public string Name { get; set; } = "";

        public GitVersion(string name, List<GitCommit> commits)
        {
            Commits = commits;
            Name = name;
        }
    }
}
