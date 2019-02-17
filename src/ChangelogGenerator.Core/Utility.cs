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
        public static List<Commit> GetCommitBetweenTags(ChangelogSettings settings, string from, string to)
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

                return commits.ToList();
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
                    if (settings.VersionFilters.Any(v => tag.FriendlyName.StartsWith(v)))
                    {
                        versions.Add(CreateVersion(tag.FriendlyName, previousTag?.CanonicalName, tag.CanonicalName, settings));

                        previousTag = tag;
                    }
                }
            }

            if (previousTag != null)
            {
                versions.Add(CreateVersion(previousTag.FriendlyName, previousTag.CanonicalName, null, settings));
            }
            versions.Reverse();

            return versions;
        }

        private static GitVersion CreateVersion(string name, string fromName, string toName, ChangelogSettings settings)
        {
            var versionName = string.IsNullOrEmpty(name) ? settings.UnreleasedTitle : name;

            var commits = GetCommitBetweenTags(settings, fromName, toName);

            return new GitVersion(versionName, commits);
        }
    }
}
