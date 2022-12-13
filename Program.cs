using Spectre.Console;
using Spectre.Console.Cli;
using EasyPlan.Commands.New;

namespace EasyPlan;

public static class Program
{
    public static int Main(string[] args)
    {
        var font = FigletFont.Load("logo/3d.flf");

        AnsiConsole.Write(
            new FigletText(font, "EasyPlan")
                .LeftAligned()
                .Color(Color.HotPink));

        var app = new CommandApp();
        app.Configure(config =>
        {
            config.SetApplicationName("easyplan");
            config.ValidateExamples();
            config.AddExample(new[] { "new", "--defaults" });

            // New Blank YAML Test Plan
            config.AddCommand<NewCommand>("new");
        });

        return app.Run(args);
    }
}