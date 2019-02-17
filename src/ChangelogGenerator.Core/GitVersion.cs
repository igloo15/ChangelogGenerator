using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    public class GitVersion
    {
        public List<Commit> Commits { get; set; } = new List<Commit>();

        public string Name { get; set; } = "";

        public GitVersion(string name, List<Commit> commits)
        {
            Commits = commits;
            Name = name;
        }
    }
}
