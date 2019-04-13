# [FilterSettings](./FilterSettings.md)

Namespace: [ChangelogGenerator]() > [Core](./../README.md) > [Settings](./README.md)

Assembly: ChangelogGenerator.Core.dll

## Summary
Filter Settings allow you to define what to match on in git commit messages

## Constructors

| Name | Summary | 
| --- | --- | 
| FilterSettings ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String)[] keys ) | Construct the FilterSettings with an initial set of keys | 


## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [List](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | Keys | The keys to match on | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | MatchCase | Match Key Case when attempting matching | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | RemoveAllKey | Remove the matched key | 
| [List](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String)> | RemoveTokens | Tokens to remove from the git commit messages to create a clean token/message | 


