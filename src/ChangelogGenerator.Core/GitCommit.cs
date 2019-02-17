using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitCommit
    {
        public string Message { get; set; }

        public string MessageShort { get; set; }

        public string Author { get; set; }

        public string AuthorEmail { get; set; }

        public string CommitDate { get; set; }

        public string SHA { get; set; }

        public string Version { get; set; }

        public string Category { get; set; }

        public string Links { get; set; }

        public static GitCommit Create(Commit commit)
        {
            return new GitCommit
            {
                Message = commit.Message,
                MessageShort = commit.MessageShort,
                Author = commit.Author.Name,
                AuthorEmail = commit.Author.Email,
                CommitDate = commit.Author.When.ToString(),
                SHA = commit.Sha
            };
        }

    }
}
