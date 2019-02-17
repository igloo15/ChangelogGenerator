using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitCommitMessageLine
    {
        public string Message { get; set; }

        public string[] Tokens { get; set; }

        public GitCommitMessageLine(string message)
        {
            Message = message;

            Tokens = message.Split(' ');
        }

        public void RemoveToken(string token)
        {
            Message = Message.Replace(token, "");
        }
    }
}
