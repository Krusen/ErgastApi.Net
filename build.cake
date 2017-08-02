#addin "Cake.FileHelpers"

var target = Argument("target", "Default");

Task("Set-Build-Version")
    .Does(() =>
{
    var projectFile = "./src/ErgastApi/ErgastApi.csproj";
    var versionPeekXpath = "/Project/PropertyGroup/Version/text()";
    var versionPokeXpath = "/Project/PropertyGroup/Version";

    var version = XmlPeek(projectFile, versionPeekXpath);
    var parts = version.Split('.');

    var buildNumber = 0;

    if (BuildSystem.IsRunningOnAppVeyor)
    {
        buildNumber = AppVeyor.Environment.Build.Number;
    }

    version = string.Join(".", parts[0], parts[1], buildNumber);
    XmlPoke(projectFile, versionPokeXpath, version);

    if (BuildSystem.IsRunningOnAppVeyor)
    {
        AppVeyor.UpdateBuildVersion(version);
    }

    Information("Set project version to " + version);
});

Task("Default")
    .IsDependentOn("Set-Build-Version");

RunTarget(target);