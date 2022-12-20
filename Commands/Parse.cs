using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

#pragma warning disable CS8765
#pragma warning disable CS8618

namespace EasyPlan.Commands.Parse;

[Description("Parse a monitor session export file to import in a Test Engine plan.")]
public sealed class ParseCommand : Command<ParseCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-e|--export <FILEPATH>")]
        [Description("The file path to export the analysis of the monitor session log.")]
        [DefaultValue("testPlan-draft.fx.yaml")]
        public string? Export { get; set; }

        [CommandOption("-a|--analysis")]
        [DefaultValue(false)]
        [Description("Run interactive session to review analysis and import into an existing test plan file")]
        public bool Analysis { get; set; }

        [CommandOption("-f|--file <FILEPATH>")]
        [DefaultValue("PowerAppsTraceEvents.json")]
        [Description("The path to the monitor session export file to be parsed")]
        public required string FilePath { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        MonitorSession? PowerAppsTraceEvents = new MonitorSession();

        AnsiConsole.Status()
            .Start("Parsing monitor session file...", ctx =>
            {
                // Read Monitor Session log file
                AnsiConsole.MarkupLine("[HotPink]LOG[/]: Reading monitor session log file from " + settings.FilePath + "...");
                Thread.Sleep(1000);

                if(File.Exists(settings.FilePath)){
                    var json = File.ReadAllText(settings.FilePath);

                    PowerAppsTraceEvents = JsonSerializer.Deserialize<MonitorSession>(json);

                    if(PowerAppsTraceEvents != null){
                        AnsiConsole.MarkupLine("[HotPink]LOG[/]: Reading Network messages...");

                        var NetworkMessages =
                            from message in PowerAppsTraceEvents.Messages
                            where message.category.Equals("Network")
                            select new
                            {
                                Name = message.name,
                                Url = message.data.request.url
                            };

                        var root = new Tree("Network Messages");
                        var table = new Table();
                        table.AddColumn("Name");
                        table.AddColumn(new TableColumn("Url").Centered());

                        foreach (var item in NetworkMessages)
                        {
                            table.AddRow(item.Name, item.Url);
                        }

                        AnsiConsole.Write(table);
                    }
                }else{
                    AnsiConsole.MarkupLine("[HotPink]LOG[/]: File not found. Check path: [link]" + Path.GetFullPath(settings.FilePath) + "[/]");
                }
            });

            if(settings.Analysis == false){
            }
        return 0;
    }
}