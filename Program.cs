using Spectre.Console;
using Spectre.Console.Cli;
using EasyPlan.Commands.New;

namespace EasyPlan;

public static class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandApp();
        app.Configure(config =>
        {
            config.SetApplicationName("easyplan");
            config.ValidateExamples();
            config.AddExample(new[] { "new", "--defaults" });

                // Run
                config.AddCommand<NewCommand>("new");
        });

        return app.Run(args);
    }
}