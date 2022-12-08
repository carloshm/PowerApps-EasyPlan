using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

#pragma warning disable CS8765

namespace EasyPlan.Commands.New;

[Description("Create a new test plan for a Test Engine project.")]
public sealed class NewCommand : Command<NewCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-c|--configuration <CONFIGURATION>")]
        [Description("The configuration to run for. The default for most projects is '[grey]Debug[/]'.")]
        [DefaultValue("Debug")]
        public string? Configuration { get; set; }

        [CommandOption("--defaults")]
        [Description("Include test plan with defaults value set. Implies [grey]all attributes with default values[/].")]
        public bool Defaults { get; set; }

        [CommandOption("-p|--project <PROJECTPATH>")]
        [Description("The path to the project file to run (defaults to the current directory if there is only one project).")]
        public string? ProjectPath { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        return 0;
    }
}