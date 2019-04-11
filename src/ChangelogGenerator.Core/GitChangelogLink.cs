using ChangelogGenerator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitChangelogLink
    {
        public string Token { get; set; }

        public string CleanToken { get; set; }

        public ChangelogLink LinkSettings { get; set; }

        public GitChangelogLink(string token, ChangelogLink settings)
        {
            Token = token;
            CleanToken = settings.Filter.CleanValue(token);
            LinkSettings = settings;
        }

        public string GetLink(ChangelogSettings settings)
        {
            var url = LinkSettings.UrlTemplate;
            var message = settings.Templates.LinkTemplate;

            url = url.Replace("{LinkKey}", Token);
            message = message.Replace("{LinkKey}", Token);

            url = url.Replace("{LinkCleanKey}", CleanToken);
            message = message.Replace("{LinkCleanKey}", CleanToken);

            message = message.Replace("{Url}", url);

            return message;
        }
    }
}
