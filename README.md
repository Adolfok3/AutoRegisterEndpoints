# Auto Endpoint Registration for .NET Minimal API

This library provides automatic endpoint registration for .NET Minimal API, eliminating the need to manually map endpoints in the `Program.cs` file. By using this library, you can streamline the process of setting up your API endpoints, making your code cleaner and more maintainable.

[![GithubActions](https://github.com/Adolfok3/autoregisterendpoints/actions/workflows/main.yml/badge.svg)](https://github.com/Adolfok3/autoregisterendpoints/actions)
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)
[![Coverage Status](https://coveralls.io/repos/github/Adolfok3/autoregisterendpoints/badge.svg?branch=main)](https://coveralls.io/github/Adolfok3/autoregisterendpoints?branch=main)
[![NuGet Version](https://img.shields.io/nuget/vpre/autoregisterendpoints)](https://www.nuget.org/packages/autoregisterendpoints)

## Installation

To install the library, use the NuGet Package Manager Console:

```sh
Install-Package AutoRegisterEndpoints
```

Or via the .NET CLI:

```sh
dotnet add package AutoRegisterEndpoints
```

## Configuration

To configure the library, follow these steps:

1. In your `Program.cs` file, add the following extension method `MapEndpoints` to `WebApplication`:

    ```csharp
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    app.MapEndpoints(); // <------

    app.Run();
    ```

2. Ensure that your endpoint classes implement the `IEndpoint` interface provided by the library. For example:

    ```csharp
    public class WeatherForecastEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("/weatherforecast", () =>
            {
                // Your endpoint logic here
            });
        }
    }
    ```

    You could also use `IEndpointRouteBuilder` to map a group of endpoints:

      ```csharp
      public class WeatherForecastEndpoint : IEndpoint
      {
          public void Map(IEndpointRouteBuilder endpointRouteBuilder)
          {
              var group = endpointRouteBuilder.MapGroup("v1/weatherforecast");

              group.MapGet("/", () =>
              {
                  // Your endpoint logic here
              });

              group.MapPost("/", () =>
              {
                  // Your endpoint logic here
              });
          }
      }
      ```

By following these steps, your endpoints will be automatically registered without the need to manually map them in the `Program.cs` file.


