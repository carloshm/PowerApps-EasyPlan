using EasyPlan.Commands.Chat;
using EasyPlan.Commands.New;
using EasyPlan.Commands.Parse;
using Spectre.Console;
using Spectre.Console.Cli;

namespace EasyPlan;
/*
easyplan new --help
easyplan new

*/
public static class Program
{
    public static int Main(string[] args)
    {
        var font = FigletFont.Load("Brand/small.flf");

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
            config.AddExample(new[] { "chat", "--help" });

            // New Blank YAML Test Plan
            config.AddCommand<NewCommand>("new");            
            // Parse Power Apps Monitor Session export 
            config.AddCommand<ParseCommand>("parse");
            // Chat with Power Apps Monitor Session export 
            config.AddCommand<ChatCommand>("chat");
        });

        return app.Run(args);
    }
}