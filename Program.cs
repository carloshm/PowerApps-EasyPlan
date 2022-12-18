using Spectre.Console;
using Spectre.Console.Cli;
using EasyPlan.Commands.New;
using EasyPlan.Commands.Parse;

namespace EasyPlan;
/*
easyplan new --help
easyplan new

*/

public static class Program
{
    public static int Main(string[] args)
    {
        var font = FigletFont.Load("Brand/3d.flf");

        AnsiConsole.Write(
            new FigletText(font, "EasyPlan")
                .LeftAligned()
                .Color(Color.HotPink));
        AnsiConsole.WriteLine();

        var app = new CommandApp();
        app.Configure(config =>
        {
            config.SetApplicationName("easyplan");
            config.ValidateExamples();
            config.AddExample(new[] { "new", "--defaults" });
            config.AddExample(new[] { "new", "--file", "test.file.yaml" });
            config.AddExample(new[] { "parse", "--file", "PowerAppsTraceEvents.json" });
            config.AddExample(new[] { "parse", "--help" });

            // New Blank YAML Test Plan
            config.AddCommand<NewCommand>("new");            
            // Parse Power Apps Monitor Session export 
            config.AddCommand<ParseCommand>("parse");
        });

        return app.Run(args);
    }
}