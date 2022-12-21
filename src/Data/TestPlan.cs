using System;
using System.Collections.Generic;
using System.ComponentModel;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

#pragma warning disable CS8618
#pragma warning disable CS8981

public class testPlan
{
    public testSuite testSuite { get; set; }
    public testSettings testSettings { get; set; }
    public environmentVariables environmentVariables { get; set; }
}
public class testSuite
{
    public required string testSuiteName { get; set; }
    public string testSuiteDescription { get; set; }
    public required string persona { get; set; }
    public required string appLogicalName { get; set; }
    public string appId { get; set; }
    public List<NetworkRequestMock> networkRequestMocks { get; set; }
    public required List<testCase> testCases { get; set; }
    public string onTestCaseStart { get; set; }
    public string onTestCaseComplete { get; set; }
    public string onTestSuiteComplete { get; set; }
}
public class testCase
{
    public string testCaseName { get; set; }
    [YamlMember(ScalarStyle = ScalarStyle.Literal)] public string testSteps { get; set; }
}
public class NetworkRequestMock
{
    public required string requestURL { get; set; }
    public string method { get; set; }
    public Dictionary<string,string> headers { get; set; }
    public required string responseDataFile { get; set; }
    [DefaultValue(null)] public string? requestBodyFile { get; set; } = null;
}
public class testSettings
{
    [DefaultValue(false)] public bool recordVideo { get; set; } = false;
    [DefaultValue(true)] public bool headless { get; set; } = true;
    [DefaultValue(false)] public bool enablePowerFxOverlay { get; set; }  = false;
    [DefaultValue(30000)] public int timeout { get; set; } = 30000;
    [DefaultValue(10)] public int workerCount { get; set; } = 10;
    [DefaultValue(null)] public string? filePath { get; set; } = null;
    public required browserConfigurations[] browserConfigurations { get; set; }
}
public class browserConfigurations
{
    public required string browser { get; set; }
    [DefaultValue(null)] public string? device { get; set; } =  null;
    [DefaultValue(null)] public int? screenHeight { get; set; } = null;
    [DefaultValue(null)] public int? screenWidth { get; set; } = null;
}

public class users
{
    public required string personaName { get; set; }
    public required string emailKey { get; set; }
    public required string passwordKey { get; set; }
}
public class environmentVariables
{
    public required users[] users { get; set; }
    [DefaultValue(null)] public string? filePath { get; set; } = null;

}