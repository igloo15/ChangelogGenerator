using ChangelogGenerator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitCommitMessageLine
    {
        public string Message { get; set; }

        public string CleanMessage { get; set; }

        public string[] Tokens { get; set; }

        public GitCommitMessageLine(string message)
        {
            Message = message;
            CleanMessage = message;

            Tokens = message.Split(' ');
        }

        public void ReplaceMessagePart(string currentMessagePart, string newMessagePart)
        {
            CleanMessage = CleanMessage.Replace(currentMessagePart, newMessagePart);
        }
    }
}
