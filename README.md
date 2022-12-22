[![.NET](https://github.com/carloshm/easyplan/actions/workflows/dotnet.yml/badge.svg)](https://github.com/carloshm/easyplan/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/carloshm/easyplan/actions/workflows/codeql.yml/badge.svg)](https://github.com/carloshm/easyplan/actions/workflows/codeql.yml)

![EasyPlan logo](/images/easyplan-title.svg "EasyPlan Logo")

# EasyPlan tool

## Overview

This repository contains the EasyPlan Tool - it simplifies your test plans creation and execution in Test Engine for Power Apps. The tool suggests different test cases based on imported monitor logs, so you can add them into a test plan ready to be reviewed and run with Test Engine. Are you looking for network mocking for SharePoint sites, Dataverse or Custom Connectors? The tool generates the required files and properties to be added into your test plan. On the other hand, it allows the creation of YAML files based on user input data, or a starter template file. 

Feedback is welcome! Please let me know what you think by opening an [issue](../../issues).

## Useful Links

- [Announcement Test Engine](https://powerapps.microsoft.com/en-us/blog/introducing-test-engine-an-open-platform-for-automated-testing-of-canvas-apps/)
- [Test Engine Source Code](https://github.com/microsoft/PowerApps-TestEngine)
- [Power Fx Overview](https://learn.microsoft.com/en-us/power-platform/power-fx/overview)

## Getting Started

The easyplan tool is distributed as a .NET Tool from NuGet.org. The installation of the tool is managed with the dotnet CLI.

### Installing easyplan

To install easyplan, use the dotnet tool install command:

```
dotnet tool install -g easyplan
```

To update to the latest version of tool, use the dotnet tool update command.

```
dotnet tool update -g easyplan
```

To uninstall it, simply type:

```
dotnet tool uninstall -g easyplan
```

Once you install the tool, you can view the list of available commands by typing:

```
easyplan --help
```

### This is how it works:

#### EasyPlan help
[![asciicast](https://asciinema.org/a/546597.svg)](https://asciinema.org/a/546597)

#### EasyPlan New
[![asciicast](https://asciinema.org/a/546599.svg)](https://asciinema.org/a/546599)

#### EasyPlan Parse
[![asciicast](https://asciinema.org/a/546600.svg)](https://asciinema.org/a/546600)


## Getting Help
For feature requests or issues using this tool please open an issue in this repository.

## Contributing
We welcome community contributions and pull requests. See CONTRIBUTING for information on how to set up a development environment and submit code.

## License
This repository is licensed under the MIT License. See LICENSE and NOTICE for more information.
