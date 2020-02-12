# Bongloy.net

[![NuGet](https://img.shields.io/nuget/v/bongloy.net.svg)](https://www.nuget.org/packages/Bongloy.net/)

The official [Bongloy](https://bongloy.com) .NET library, supporting .NET Standard 1.2+, .NET Core 1.0+, and .NET Framework 4.5+.

## Installation

Using the [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```sh
dotnet add package Bongloy.net
```

Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference):

```sh
nuget install Bongloy.net
```

Using the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```powershell
Install-Package Bongloy.net
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Bongloy.net".
5. Click on the Bongloy.net package, select the appropriate version in the
   right-tab and click *Install*.

## Usage

```c#
var bongloyApiKey = "BONGLOY_SECRET_KEY";

new BongloyClient(bongloyApiKey);

var options = new ChargeCreateOptions
{
    Amount = 2000,
    Currency = "USD",
    Source = token_source,
    Description = "My First Test Charge (created for API docs)",
};

var service = new ChargeService();
service.Create(options);
```
## Documentation

For a comprehensive list of examples, check out the [API
documentation](https://sandbox.bongloy.com/documentation).

