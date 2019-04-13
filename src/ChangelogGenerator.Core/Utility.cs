using ChangelogGenerator.Core.Settings;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangelogGenerator.Core
{
    internal static class Utility
    {
        public static List<GitCommit> GetCommitBetweenTags(ChangelogSettings settings, string versionName, string from, string to)
        {
            using (var repo = new Repository(settings.GitRepoLocation))
            {
                object fromTag = null;
                object toTag = null;

                if (string.IsNullOrEmpty(from))
                    fromTag = repo.Branches[settings.LatestCodeBranch];
                else
                    fromTag = repo.Tags[from];

                if (string.IsNullOrEmpty(to))
                    toTag = repo.Branches[settings.LatestCodeBranch];
                else
                    toTag = repo.Tags[to];

                if (fromTag == null || toTag == null)
                {
                    throw new Exception($"Failed to find tags - from: {fromTag}  to: {toTag}");
                }

                CommitFilter filter = null;

                if (string.IsNullOrEmpty(from))
                {
                    filter = new CommitFilter
                    {
                        IncludeReachableFrom = toTag
                    };
                }
                else
                {
                    filter = new CommitFilter
                    {
                        ExcludeReachableFrom = fromTag,
                        IncludeReachableFrom = toTag
                    };
                }

                var commits = repo.Commits.QueryBy(filter);

                return commits.Select(c => GitCommit.Create(versionName, c)).ToList();
            }
        }

        public static List<GitVersion> GetVersions(ChangelogSettings settings)
        {
            Tag previousTag = null;
            List<GitVersion> versions = new List<GitVersion>();
            using (var repo = new Repository(settings.GitRepoLocation))
            {
                foreach (var tag in repo.Tags)
                {
                    if (settings.VersionFilter.IsMatch(tag.FriendlyName))
                    {
                        versions.Add(CreateVersion(tag.FriendlyName, previousTag?.CanonicalName, tag.CanonicalName, settings));

                        previousTag = tag;
                    }
                }
            }

            if (previousTag != null)
            {
                versions.Add(CreateVersion(null, previousTag.CanonicalName, null, settings));
            }
            versions.Reverse();

            return versions;
        }

        public static bool IsMatch(this FilterSettings settings, string value)
        {
            return settings.Keys.Any(k => value.StartsWith(k, settings.MatchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase));
        }

        public static string CleanValue(this FilterSettings settings, string value)
        {
            foreach(var token in settings.RemoveTokens)
            {
                value = value.Replace(token, "");
            }

            if(settings.RemoveAllKey)
            {
                var matchingKeys = settings.Keys.Where(k => value.StartsWith(k, settings.MatchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase));

                if(!settings.MatchCase)
                {
                    var length = matchingKeys.Max(k => k.Length);
                    value = value.Substring(length);
                }
                else
                {
                    foreach (var matchedKey in matchingKeys)
                    {
                        value = value.Replace(matchedKey, "");
                    }
                }
            }

            return value;
        }

        private static GitVersion CreateVersion(string name, string fromName, string toName, ChangelogSettings settings)
        {
            var versionName = string.IsNullOrEmpty(name) ? settings.UnreleasedTitle : name;

            var commits = GetCommitBetweenTags(settings, versionName, fromName, toName);

            var categories = GitChangelogCategoryParser.GetCategories(commits, settings);

            return new GitVersion(versionName, commits, categories);
        }


    }
}
