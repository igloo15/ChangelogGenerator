# [ChangelogSettings](./ChangelogSettings.md)

Namespace: [ChangelogGenerator]() > [Core](./../README.md) > [Settings](./README.md)

Assembly: ChangelogGenerator.Core.dll

## Summary
The main Changelog Config

## Constructors

| Name | Summary | 
| --- | --- | 
| ChangelogSettings (  ) |  | 


## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | AllCommits | Determines if all commits should be searched | 
| [List](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1)\<[ChangelogCategory](./ChangelogCategory.md)> | Categories | The categories of a specific version in a changelog | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | ChangelogLocation | Defines the location of where the changelog should be written | 
| [Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32) | GitRepoCommitLimit | Defines how far back the changelog should search for git commits and tags | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GitRepoLocation | Defines the location of the gitrepo relative to this changelog | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | LatestCodeBranch | Determines the name of the latest code branch for use when calculating unreleased git items | 
| [List](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1)\<[ChangelogLink](./ChangelogLink.md)> | Links | Defines links that can appear on each changelog item | 
| [ChangelogTemplateSettings](./ChangelogTemplateSettings.md) | Templates | Defines the templates for how the changelog should look | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | TestMode | Determines if this changelog generation is running in test mode | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | UnreleasedTitle | Defines the title of the unreleased git changelog items | 
| [List](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | VersionFilters |  | 


