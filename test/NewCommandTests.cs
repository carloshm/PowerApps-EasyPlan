using EasyPlan;
using Moq;
using Spectre.Console.Cli;
using Spectre.Console;
using System;
using System.Collections.Generic;
using Xunit;
using EasyPlan.Commands.New;
using System.IO;

namespace EasyPlan.tests;

public class NewCommandTests
{
    private readonly IRemainingArguments _remainingArgs = new Mock<IRemainingArguments>().Object;

    [Fact]
    public void Execute_WithDefaults()
    {
        // Given
        var command = new NewCommand();
        var context = new CommandContext(_remainingArgs, "defaults", true);
        string testPath = String.Format(
            "{0}{1}{2}",
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
            Path.DirectorySeparatorChar,
            "test.json");

        var settings = new NewCommand.Settings();
        settings.Defaults = true;
        settings.FilePath = testPath;

        AnsiConsole.Record();

        // When
        var result = command.Execute(context, settings);

        // Then
        Assert.Equal(0, result);
        var text = AnsiConsole.ExportText();
        Assert.Contains("LOG: Configuring test plan template...", text);
        Assert.Contains("LOG: Serialize test plan and save file...", text);
        Assert.Contains("LOG: " + testPath, text);
    }
}
