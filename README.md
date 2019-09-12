# LoggerWrapperOfILogger

[![Nuget](https://img.shields.io/nuget/v/LoggerWrapperOfILogger)](https://www.nuget.org/packages/LoggerWrapperOfILogger/)

Useful for wrapping `ILogger` to `ILogger<Class>`

## Install

```csproj
<PackageReference Include="LoggerWrapperOfILogger" Version="1.0.0" />
```

## Usage

Example use case

```csharp
using System;
using System.Threading.Tasks;
using LoggerWrapperOfILogger;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MyCompany.FunctionApp
{
    public class TimerFunction
    {
        [FunctionName("MyTimerFunction")]
        public async Task Run([TimerTrigger("0 * * * * *")] TimerInfo timer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}");
            var service = new MyService(new LoggerWrapper<MyService>(log));
            await service.Run();
            log.LogInformation($"C# Timer trigger function finished at: {DateTime.UtcNow}");
        }
    }
}
```
