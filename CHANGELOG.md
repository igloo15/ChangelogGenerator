# Changelog
## Unreleased
### Summary
Version 1.0.1 is a bug fix release that fixes two issues with links not showing up correctly and categories not being added if they are empty. 

### Add
*  option to include or not include empty templates


### Changes
*  update build script
*  appveyor config updated to only build master
*  update changelog settings getting ready to work on   [issue-1](https://github.com/igloo15/ChangelogGenerator/issues/issue-1) [issue-2](https://github.com/igloo15/ChangelogGenerator/issues/issue-2)


### Fixed
*  fixed  [issue-2](https://github.com/igloo15/ChangelogGenerator/issues/issue-2)
*  fixed  [issue-1](https://github.com/igloo15/ChangelogGenerator/issues/issue-1)
*  fixed incorrect label for NoIssuesTemplate in schema and example changelog configs


### Other Commits
*  N/A 




## v1.0.0
### Summary


### Add
*  end changelog template added
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
*  basic code to get GitVersions and GitCommits


### Changes
*  update changelog config
*  update build scripts to allow for correct markdown documentation
*  update readme with more information
*  update changelog settings
*  Update buildscript to build nuget packages
*  removed press enter to exit to prepare for official build
*  Remove GitCommitParser


### Fixed
*  schema requirements fixed
*  change log schema fixed so versionfilters is versionfilter
*  build output fixed
*  category order is determined by name so order is always consistent
*  csproj file for building
*  fix new incubator version having a bad Dump Method
*  If directory is empty then use current directory
*  correct to be accurate nuget package id
*  bad template for category in json file
*  Changelog setting file is updated to be correct
*  Remove empty lines


### Other Commits
* Merge branch 'develop'
* #Update Parsing GitCommits to GitChangelogItems




## v0.1.0
### Summary


### Add
*  N/A 


### Changes
*  N/A 


### Fixed
*  N/A 


### Other Commits
* #Initial Commit





