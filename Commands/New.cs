using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

#pragma warning disable CS8765
#pragma warning disable CS8618

namespace EasyPlan.Commands.New;

[Description("Create a new sample test plan file for a Test Engine project.")]
public sealed class NewCommand : Command<NewCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-c|--configuration <CONFIGURATION>")]
        [Description("The configuration to run for. The default for most projects is '[red]Debug[/]'.")]
        [DefaultValue("Debug")]
        public string? Configuration { get; set; }

        [CommandOption("--defaults")]
        [DefaultValue(false)]
        [Description("Include all test plan properties not set. This will populate properties with a default value.")]
        public bool Defaults { get; set; }

        [CommandOption("-f|--file <FILEPATH>")]
        [DefaultValue("testPlan.fx.yaml")]
        [Description("The path to the test plan file to generate (defaults to the current directory if not present).")]
        public string FilePath { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var testPlan = new testPlan
        {
            testSuite = new testSuite(){
                testSuiteName = "Calculator",
                testSuiteDescription = "Verifies that the calculator app works. The calculator is a component.",
                persona = "User1",
                appLogicalName = "new_calculator_a3613",
                networkRequestMocks = new List<NetworkRequestMock>{
                        new  NetworkRequestMock() {
                            requestURL = "https://*.azure-apim.net/invoke",
                            method = "POST",
                            headers = new Dictionary<string,string>(){
                                {"x-ms-request-method","GET"}            
                            },
                            responseDataFile = "../../samples/connector/response.json",
                            requestBodyFile = ""
                        }
                },
                testCases = new List<testCase>{
                        new  testCase() {
                            testCaseName = "Default Check",
                            testSteps = "= Screenshot('calculator_loaded.png');\nAssert(Calculator_1.Number1Label.Text = '100', 'Validate default value for number 1 label');\nAssert(Calculator_1.Number2Label.Text = '100', 'Validate default value for number 2 label');"
                        }
                }
            },
            testSettings = new testSettings(){
                recordVideo = true,
                headless = true,
                enablePowerFxOverlay = true,
                browserConfigurations = new browserConfigurations[]
                {
                    new browserConfigurations
                    {
                        browser = "Firefox"
                    }
                }
            },
            environmentVariables = new environmentVariables(){
                users = new users[]{
                    new users{
                        personaName = "User1",
                        emailKey = "user1Email",
                        passwordKey = "user1Password"
                    },
                    new users{
                        personaName = "User2",
                        emailKey = "user2Email",
                        passwordKey = "user2Password"
                    }
                }
            }
        };

        DefaultValuesHandling defaultValues = DefaultValuesHandling.OmitNull;

        if(settings.Defaults == false){
            defaultValues = DefaultValuesHandling.OmitDefaults;
        }

        using (StreamWriter writer = new StreamWriter(settings.FilePath))
        {
            var serializer = new SerializerBuilder()
                .ConfigureDefaultValuesHandling(defaultValues)
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            serializer.Serialize(writer, testPlan);
        }

        return 0;
    }
}