#l "nuget:?package=Cake.igloo15.Scripts.Bundle.CSharp&version=1.0.0"

var target = Argument<string>("target", "Default");


Task("Pack")
    .IsDependentOn("Standard-All")
    .IsDependentOn("CSharp-NetCore-Pack-All")
    .IsDependentOn("NuGet-Package")
    .IsDependentOn("Changelog-Generate")
    .IsDependentOn("Markdown-Generate-Api")
    .CompleteTask();

Task("Push")
    .IsDependentOn("Pack")
    .IsDependentOn("NuGet-Push")
    .CompleteTask();

    

Task("Default")
    .IsDependentOn("Pack");

Task("Deploy")
	.IsDependentOn("Push");

RunTarget(target);
