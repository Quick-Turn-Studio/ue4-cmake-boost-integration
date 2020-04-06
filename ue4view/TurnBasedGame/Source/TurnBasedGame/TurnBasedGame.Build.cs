using UnrealBuildTool;
using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;

public class TurnBasedGame : ModuleRules
{
public TurnBasedGame(ReadOnlyTargetRules Target) : base(Target)
{
    PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

    PublicDependencyModuleNames.AddRange(new string[] {
        "Core", "CoreUObject", "Engine", "InputCore"
    });

    PrivateDependencyModuleNames.AddRange(new string[] {});

    bUseRTTI = true;
    bEnableExceptions = true;

    LoadGameModel(Target);
}

    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string ThirdPartyPath
    {
        get
        {
            return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/"));
        }
    }

    private string[] getGameModelLibraries()
    {
        return new string[] { "coreLib", "offlineModel" };
    }

    private bool LoadGameModel(ReadOnlyTargetRules Target)
    {
        if (Target.Platform != UnrealTargetPlatform.Win64)
        {
            return false;
        }
        var isModelBuilded = BuildModel(Target);

        if (!isModelBuilded)
        {
            return false;
        }

        const string envVariableName = "Path";
        PublicIncludePaths.Add(getBoostIncludePath(envVariableName));

        var LibrariesPath = Path.Combine(ThirdPartyPath, "generated", "lib");

        foreach (var libName in getGameModelLibraries())
        {
            var libraryPath = Path.Combine(LibrariesPath, libName + ".lib");
            PublicAdditionalLibraries.Add(libraryPath);
        }
        PublicIncludePaths.Add(Path.Combine(ThirdPartyPath, "generated", "include"));

        return true;
    }

private string getBoostIncludePath(string variable)
{
    var boostDirectory = "boost";
    var exampleBoostFile = "optional.hpp";
    var result = Environment.GetEnvironmentVariable(variable)
        .Split(';')
        .FirstOrDefault((path) => {
            var filePath = Path.Combine(path,
                                        boostDirectory,
                                        exampleBoostFile);
            return File.Exists(filePath);
    });
    return Path.Combine(result);
}

    private bool BuildModel(ReadOnlyTargetRules Target)
    {
        const string buildType = "Release";       

        var buildDirectory = "model-build-" + buildType;
        var buildPath = Path.Combine(ThirdPartyPath, "generated", buildDirectory);

        var configureCommand = CreateCMakeBuildCommand(buildPath, buildType);
        var configureCode = ExecuteCommandSync(configureCommand);
        if (configureCode != 0)
        {
            Console.WriteLine("Cannot configure CMake project. Exited with code: "
                              + configureCode);
            return false;
        }

        var installCommand = CreateCMakeInstallCommand(buildPath, buildType);
        var buildCode = ExecuteCommandSync(installCommand);
        if (buildCode != 0)
        {
            Console.WriteLine("Cannot build project. Exited with code: " + buildCode);
            return false;
        }
        return true;
    }

    private string CreateCMakeBuildCommand(string buildDirectory,
                                           string buildType)
    {
        const string program = "cmake.exe";
        // root/ue4View/TurnBasedGame/Source/TurnBasedGame
        var currentDir = ModulePath;
        var rootDirectory = Path.Combine(currentDir, "..", "..", "..", "..");
        var installPath = Path.Combine(ThirdPartyPath, "generated");
        var sourceDir = Path.Combine(rootDirectory, "model");

        var arguments = " -G \"Visual Studio 15 2017\"" +
                        " -S " + sourceDir +
                        " -B " + buildDirectory +
                        " -A x64 " +
                        " -T host=x64" +
                        " -DCMAKE_BUILD_TYPE=" + buildType +
                        " -DCMAKE_INSTALL_PREFIX=" + installPath;

        return program + arguments;
    }

    private string CreateCMakeInstallCommand(string buildDirectory,
                                             string buildType)
    {
        return "cmake.exe --build " + buildDirectory +
               " --target install --config " + buildType;
    }

    private int ExecuteCommandSync(string command)
    {
        Console.WriteLine("Running: " + command);
        var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
        {
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            WorkingDirectory = ModulePath
        };

        StringBuilder sb = new StringBuilder();
        Process p = Process.Start(processInfo);
        p.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
        p.BeginOutputReadLine();
        p.WaitForExit();

        return p.ExitCode;
    }
}
