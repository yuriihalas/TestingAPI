using Microsoft.Extensions.Configuration;

namespace TestingApi.main.sharp;

public static class ResourceUtils
{
    private const string ResourcePath = "src/main/resources/appsettings.json";

    public static Dictionary<string, string>? AppSettings { get; private set; }

    public static void LoadResource()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(GetSourceDir())
            .AddJsonFile(ResourcePath)
            .Build();

        AppSettings = config.Get<Dictionary<string, string>>();
    }

    public static string GetSourceDir()
    {
        var projectDirectory = Directory.GetCurrentDirectory();
        while (projectDirectory != null && !File.Exists(Path.Combine(projectDirectory, "TestingApi.csproj")))
            projectDirectory = Directory.GetParent(projectDirectory)?.FullName;

        return projectDirectory ?? throw new InvalidOperationException();
    }
}