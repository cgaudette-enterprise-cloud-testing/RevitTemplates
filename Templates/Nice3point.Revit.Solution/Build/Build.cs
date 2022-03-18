<!--#if (Installer || Bundle)
using System.Text.RegularExpressions;
#endif-->
using Nuke.Common;
<!--#if (!NoPipeline)
using Nuke.Common.Git;
#endif-->
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.VSWhere;

partial class Build : NukeBuild
{
    readonly AbsolutePath ArtifactsDirectory = RootDirectory / ArtifactsFolder;
<!--#if (GitHubPipeline)
    readonly AbsolutePath ChangeLogPath = RootDirectory / "Changelog.md";
#endif-->
<!--#if (!NoPipeline)
    [GitRepository] readonly GitRepository GitRepository;
#endif-->
    [Solution] readonly Solution Solution;

    public static int Main() => Execute<Build>(x => x.Cleaning);

    List<string> GetConfigurations(params string[] startPatterns)
    {
        var configurations = Solution.Configurations
            .Select(pair => pair.Key)
            .Where(s => startPatterns.Any(s.StartsWith))
            .Select(s =>
            {
                var platformIndex = s.LastIndexOf('|');
                return s.Remove(platformIndex);
            })
            .ToList();
        if (configurations.Count == 0) throw new Exception($"Can't find configurations in the solution by patterns: {string.Join(" | ", startPatterns)}.");
        return configurations;
    }
<!--#if (Installer || Bundle)

    IEnumerable<IGrouping<string, DirectoryInfo>> GetBuildDirectories()
    {
        var directories = new List<DirectoryInfo>();
        foreach (var projectName in Projects)
        {
            var project = BuilderExtensions.GetProject(Solution, projectName);
            var directoryInfo = new DirectoryInfo(project.GetBinDirectory()).GetDirectories();
            directories.AddRange(directoryInfo);
        }

        if (directories.Count == 0) throw new Exception("There are no packaged assemblies in the project. Try to build the project again.");

        var versionRegex = new Regex(@"^.*R\d+ ?");
        var addInsDirectory = directories
            .Where(dir => dir.Name.StartsWith(AddInBinPrefix))
            .Where(dir => dir.Name.Contains(BuildConfiguration))
            .GroupBy(dir => versionRegex.Replace(dir.Name, string.Empty));

        return addInsDirectory;
    }
#endif-->
}