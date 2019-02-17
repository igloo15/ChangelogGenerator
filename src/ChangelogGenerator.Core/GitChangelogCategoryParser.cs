using ChangelogGenerator.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal class GitChangelogCategoryParser
    {

        public static List<GitChangelogCategory> GetCategories(List<GitCommit> commits, ChangelogSettings settings)
        {
            var categories = new List<GitChangelogCategory>();
            List<GitChangelogItem> items = commits.SelectMany(c => ParseCommitMessages(c, settings)).ToList();

            foreach(var group in items.GroupBy(i => i.Category))
            {
                GitChangelogCategory category = new GitChangelogCategory();

                category.Name = group.Key;
                category.Items = group.ToList();
                categories.Add(category);
            }

            return categories;
        }

        public static List<GitChangelogItem> ParseCommitMessages(GitCommit message, ChangelogSettings settings)
        {
            List<GitChangelogItem> items = new List<GitChangelogItem>();

            var defaultCategory = settings.Categories.FirstOrDefault(c => c.IsDefault)?.DisplayName;

            foreach (var line in message.GetMessageLines())
            {
                var messageLine = new GitCommitMessageLine(line);
                
                GitChangelogItem cm = new GitChangelogItem();
                cm.Commit = message;
                cm.Category = GetCategory(settings, cm, messageLine) ?? defaultCategory;
                cm.Links = GetLinkText(settings, cm, messageLine);
                cm.Message = GetMessage(settings, cm, messageLine);

                items.Add(cm);
            }

            return items;
        }

        public static string GetMessage(ChangelogSettings settings, GitChangelogItem item, GitCommitMessageLine line)
        {
            var message = line.Message;

            message = message.Replace("{Links}", item.Links);

            message = message.Replace("{Category}", item.Category);

            message = item.Commit.Parse(message);
            
            message = message.Trim();
            return message;
        }

        public static string GetCategory(ChangelogSettings settings, GitChangelogItem message, GitCommitMessageLine line)
        {
            foreach (var token in line.Tokens)
            {
                var category = settings.Categories.FirstOrDefault(c => c.Keys.Any(k => token.StartsWith(k));
                if (category != null)
                {
                    line.RemoveToken(token);
                    return category.DisplayName;
                }
            }
            return null;
        }

        public static string GetLinkText(ChangelogSettings settings, GitChangelogItem message, GitCommitMessageLine line)
        {
            List<GitChangelogLink> links = new List<GitChangelogLink>();
            foreach (var token in line.Tokens)
            {
                var link = settings.Links.FirstOrDefault(c => c.Keys.Any(k => token.StartsWith(k));
                if (link != null)
                {
                    line.RemoveToken(token);
                    links.Add(new GitChangelogLink(token, link));
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach(var link in links)
            {
                sb.Append(link.GetLink()).Append(" ");
            }
            return sb.ToString();
        }

    }
}
