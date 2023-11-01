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
using System.Security;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI;
using System.Threading.Tasks;

#pragma warning disable CS8765
#pragma warning disable CS8618

namespace EasyPlan.Commands.Chat;

[Description("Chat with a monitor session export file to update a Test Plan.")]
public sealed class ChatCommand : Command<ChatCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-e|--export <FILEPATH>")]
        [Description("The Test Plan file path to update.")]
        [DefaultValue("testPlan-draft.fx.yaml")]
        public string? Export { get; set; }

        [CommandOption("-f|--file <FILEPATH>")]
        [DefaultValue("PowerAppsTraceEvents.json")]
        [Description("The path to the monitor session export file to be parsed")]
        public string FilePath { get; set; } = string.Empty;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        // Run the async method and wait for it to complete.
        // This will block the calling thread.
        return ExecuteAsync(context, settings).GetAwaiter().GetResult();
    }
    public static async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        AnsiConsole.MarkupLine("[HotPink]NOTE[/]: You could write the following commands");
        AnsiConsole.Write(new Rows(
            new Text("* 'exit' to finish."),
            new Text("* 'key' to change Azure OpenAI Key"),
            new Text("* 'url' to change Azure OpenAI EndPoint")
        ));
        AnsiConsole.MarkupLine("");
        const string deploymentName = "gpt-35-turbo";

        //SecureString apiKey = GetAzureOpenAIKey();
        AnsiConsole.MarkupLine("[HotPink]Enter Azure OpenAI information:[/]");
        string apiKey = GetUnsafeAzureOpenAIKey();
        string ApiEndPoint = GetAzureOpenAIEndpoint();
        AnsiConsole.MarkupLine("");

        var kernel = new KernelBuilder()
            .WithAzureChatCompletionService(deploymentName, ApiEndPoint, apiKey)
            .Build();

        while (true)
        {
            var input = AnsiConsole.Ask<string>("[HotPink]You[/] > ");
            switch (input.ToLower())
            {
                case "exit":
                    return 0;
                case "key":
                    apiKey = GetUnsafeAzureOpenAIKey();
                    kernel = new KernelBuilder()
                        .WithAzureChatCompletionService(deploymentName, ApiEndPoint, apiKey)
                        .Build();
                    continue;
                case "url":
                    ApiEndPoint = GetAzureOpenAIEndpoint();
                    kernel = new KernelBuilder()
                        .WithAzureChatCompletionService(deploymentName, ApiEndPoint, apiKey)
                        .Build();
                    continue;
            }
            
            // Process the input here
            // TODO include Stream response
            var output = await ProcessInputAsync(input, kernel);
            AnsiConsole.MarkupLine(output);
        }
    }

    private static async Task<string> ProcessInputAsync(string input, IKernel kernel)
    {
        try{
            var result = await kernel.InvokeSemanticFunctionAsync(
                input,
                requestSettings: new OpenAIRequestSettings()
                {
                    Temperature = 0,
                    TopP = 1,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0
                });
        
            return $"[green]EasyPlan[/] > {result}";
        }
        catch (Exception ex)
        {
            string message = ParseError(ex.Message).Message;
            var errorDetails = message;
            return $"EasyPlan > {errorDetails}";
        }
    }

    private static SecureString GetAzureOpenAIKey()
    {
        var keyInput = AnsiConsole.Prompt(
            new TextPrompt<string>("[green]Azure OpenAI API Key[/]?")
            .PromptStyle("red")
            .Secret());

        var secureKey = new SecureString();
        foreach (char character in keyInput)
        {
            secureKey.AppendChar(character);
        }
        secureKey.MakeReadOnly();

        return secureKey;
    }

    private static string GetAzureOpenAIEndpoint()
    {
        string ApiEndPoint = AnsiConsole.Prompt(new TextPrompt<string>("[green]Azure OpenAI EndPoint[/]?")
            .PromptStyle("red"));

        return ApiEndPoint;
    }

    private static string GetUnsafeAzureOpenAIKey()
    {
        var keyInput = AnsiConsole.Prompt(
            new TextPrompt<string>("[green]Azure OpenAI API Key[/]?")
            .PromptStyle("red")
            .Secret());

        return keyInput;
    }
    private static (string Message, string Type, string Code) ParseError(string errorContent)
    {
        try
        {
            int startIndex = errorContent.IndexOf("{");
            int endIndex = errorContent.LastIndexOf("}");

            if (startIndex == -1 || endIndex == -1 || endIndex <= startIndex)
            {
                return ("Failed to find JSON content in error message.", "Parse Error", "Parse Error");
            }

            string jsonContent = errorContent.Substring(startIndex, endIndex - startIndex + 1).Trim();

            using JsonDocument doc = JsonDocument.Parse(jsonContent);
            var root = doc.RootElement;
            if (root.TryGetProperty("error", out var errorProp))
            {
                string message = errorProp.GetProperty("message").GetString() ?? "Unknown error message.";
                string type = errorProp.GetProperty("type").GetString() ?? "Unknown error type.";
                string code = errorProp.GetProperty("code").GetString() ?? "Unknown error code.";

                return (Message: message, Type: type, Code: code);
            }
        }
        catch (JsonException jsonEx)
        {
            return ($"Failed to parse error message: {jsonEx.Message}", "Parse Error", "Parse Error");
        }

        return ("Unknown error occurred.", "Unknown Error", "Unknown Error");
    }

}