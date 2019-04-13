ChangelogGenerator
===

Core: [![NuGet](https://img.shields.io/nuget/v/igloo15.ChangelogGenerator.Core.svg)](https://www.nuget.org/packages/igloo15.ChangelogGenerator.Core/)

Tool: [![NuGet](https://img.shields.io/nuget/v/igloo15.ChangelogGenerator.Tool.svg)](https://www.nuget.org/packages/igloo15.ChangelogGenerator.Tool/)


A dotnet global tool of the generating Changelog

## Install

```
dotnet tools install -g igloo15.ChangelogGenerator.Core
```

```
dotnet tools install -g igloo15.ChangelogGenerator.Tool
```

## Usage

```
dotnet changelog-generator --help
ChangelogGenerator 0.10.0
Copyright (C) 2018 Igloo15

  -m, --make-config               (Default: false) When this options is defined the server will create a config in
                                  current working directory and immediately close

  --help                          Display this help screen.

  --version                       Display version information.
```

## Config

See the config schema [here](./src/ChangelogGenerator.Core/changelog.schema.json)

### Example Config

```json
{
  "$schema": "../ChangelogGenerator.Core/changelog.schema.json",
  "Categories": [
    {
      "Filter": {
        "Keys": [ "#Summary" ]
      },
      "DisplayName": null,
      "IsSummary": false
    },
    {
      "Filter": {
        "Keys": [ "#Commits" ]
      },
      "DisplayName": "Other Commits",
      "IsDefault": true
    },
    {
      "Filter": {
        "Keys": [ "#Add" ]
      },
      "DisplayName": "Add"
    },
    {
      "Filter": {
        "Keys": [ "#Change", "#Changes" ]
      },
      "DisplayName": "Changes",
      "IsSummary": true
    },
    {
      "Filter": {
        "Keys": [ "#FIXED", "#FIX" ]
      },
      "DisplayName": "Fixed"
    }
  ],
  "Links": [
    {
      "Filter": {
        "Keys": [ "#issue" ],
        "RemoveTokens": [ "#issue" ],
        "RemoveAllKey":  false
      },      
      "UrlTemplate": "https://github.com/igloo15/ChangelogGenerator/issues/{LinkCleanKey}"
    }
  ],
  "VersionFilter": {
    "Keys":[ "v" ]
  },
  "Templates": {
    "TitleTemplate": "# Changelog",
    "VersionTemplate": "## {Version}",
    "CategoryTemplate": "### {Category}",
    "IssueTemplate": "* {Message} {Links}",
    "LinkTemplate": "[{LinkCleanKey}]({Url})",
    "NoIssueTemplate": " N/A ",
    "EndCategoryTemplate": "\n",
    "EndVersionTemplate": "\n",
    "EndChangelogTemplate": "",
    "SummarySentenceTemplate": "{Message} "
  },
  "ChangelogLocation": "./CHANGELOG.md",
  "GitRepoLocation": "D:\\Development\\Projects\\Cake.igloo15",
  "UnreleasedTitle": "Unreleased",
  "GitRepoCommitLimit": -1,
  "AllCommits": true,
  "TestMode": false,
  "LatestCodeBranch": "develop"
}

```

## Code

```csharp
ChangelogCore core = new ChangelogCore();
core.Generate();
```

```csharp
ChangelogSettings settings = new ChangelogSettings();
// Modify Settings

// Generate Config
ChangelogCore core = new ChangelogCore();
core.Generate(settings);
```

## Api

See all api documentation [here](./docs/api/README.md)