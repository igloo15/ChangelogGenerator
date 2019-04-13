# [ChangelogCategory](./ChangelogCategory.md)

Namespace: [ChangelogGenerator]() > [Core](./../README.md) > [Settings](./README.md)

Assembly: ChangelogGenerator.Core.dll

## Summary
A Changelog Category is a section of the changelog for a specific version

## Constructors

| Name | Summary | 
| --- | --- | 
| ChangelogCategory (  ) |  | 


## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | DisplayName | The Display name of this category | 
| [FilterSettings](./FilterSettings.md) | Filter | Filter determines if the git line in a commit message is part of this category | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | IsDefault | Determines if this is a default category for git lines that match no filter | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | IsSummary | Determines if this category is part of the summary | 


