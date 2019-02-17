using ChangelogGenerator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitChangelogLink
    {
        public string Token { get; set; }

        public ChangelogLink LinkSettings { get; set; }

        public GitChangelogLink(string token, ChangelogLink settings)
        {
            Token = token;
            LinkSettings = settings;
        }

        public string GetLink()
        {
            var message = LinkSettings.UrlTemplate;
            var cleanToken = Token;
            foreach(var key in LinkSettings.ReplaceTokens)
            {
                cleanToken = cleanToken.Replace(key, "");
            }

            message = message.Replace("{LinkKey}", Token);
            message = message.Replace("{LinkCleanKey}", cleanToken);
            return message;
        }
    }
}
