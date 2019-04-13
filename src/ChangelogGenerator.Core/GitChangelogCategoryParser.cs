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

            foreach(var categorySetting in settings.Categories)
            {
                var categoryItems = items.Where(i => i.Category == categorySetting.DisplayName).ToList();

                GitChangelogCategory category = new GitChangelogCategory();

                category.Name = categorySetting.DisplayName;
                category.Items = categoryItems;
                category.Summary = categorySetting.IsSummary;

                if(settings.IncludeEmptyCategories || category.Items.Count > 0)
                    categories.Add(category);
            }

            return categories;
        }

        public static List<GitChangelogItem> ParseCommitMessages(GitCommit message, ChangelogSettings settings)
        {
            List<GitChangelogItem> items = new List<GitChangelogItem>();

            var defaultCategory = settings.Categories.FirstOrDefault(c => c.IsDefault)?.DisplayName;
            var summaryCategory = settings.Categories.FirstOrDefault(c => c.IsSummary)?.DisplayName;

            foreach (var line in message.GetMessageLines())
            {
                var messageLine = new GitCommitMessageLine(line);
                
                GitChangelogItem cm = new GitChangelogItem();
                cm.Commit = message;

                var category = GetCategory(settings, cm, messageLine) ?? defaultCategory;
                if (string.IsNullOrEmpty(category))
                    continue;

                if (!string.IsNullOrEmpty(summaryCategory) && category.Equals(summaryCategory))
                    cm.PartOfSummary = true;

                cm.Category = category;
                cm.Links = GetLinkText(settings, cm, messageLine);
                cm.Message = GetMessage(settings, cm, messageLine);


                items.Add(cm);
            }

            return items;
        }

        public static string GetMessage(ChangelogSettings settings, GitChangelogItem item, GitCommitMessageLine line)
        {
            var message = item.PartOfSummary ? settings.Templates.SummarySentenceTemplate : settings.Templates.IssueTemplate;

            message = message.Replace("{Message}", line.CleanMessage);

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
                var category = settings.Categories.FirstOrDefault(c => c.Filter.IsMatch(token));
                if (category != null)
                {
                    var cleanToken = category.Filter.CleanValue(token);
                    line.ReplaceMessagePart(token, cleanToken);
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
                var link = settings.Links.FirstOrDefault(c => c.Filter.IsMatch(token));
                if (link != null)
                {
                    links.Add(new GitChangelogLink(token, link));
                    line.ReplaceMessagePart(token, "");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach(var link in links)
            {
                sb.Append(link.GetLink(settings)).Append(" ");
            }
            return sb.ToString();
        }

    }
}
