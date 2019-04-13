# Changelog
## Unreleased
### Fixed
*  build output fixed
*  category order is determined by name so order is always consistent
*  csproj file for building
*  fix new incubator version having a bad Dump Method
*  If directory is empty then use current directory
*  correct to be accurate nuget package id
*  bad template for category in json file
*  Changelog setting file is updated to be correct
*  Remove empty lines


### Add
*  new type of filtering for versions, categories, and links
*  replace key and replace token list added to line and link parsing
*  summary categories now work
*  schema for json added
*  repo location commandline option added
*  error catching in case missing config files and git folder
*  add appveyor ci building
*  Update output to create Changelog file or be in test mode
*  Title template added
*  end category and end version templates
*  templating for category and version complete
*  Url Link Templates now parsed
*  Now using Message Template
*  GitChangelogItem message parsed
*  new git classes to parse commits into changelog items
*  New GitCommit Class added to break out individual git commits
* ed basic code to get GitVersions and GitCommits


### Changes
*  update changelog settings
*  Update buildscript to build nuget packages
*  removed press enter to exit to prepare for official build
*  Remove GitCommitParser


### Other Commits
* #Update Parsing GitCommits to GitChangelogItems




## v0.1.0
### Other Commits
* #Initial Commit




