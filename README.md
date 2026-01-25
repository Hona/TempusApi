# TempusApi

[![Nuget](https://img.shields.io/nuget/v/TempusApi)](https://www.nuget.org/packages/TempusApi)

Tempus API client for https://tempus2.xyz. Targets .NET 10 and is distributed via NuGet.

Install
```
dotnet add package TempusApi
```

Quick start
```csharp
using TempusApi;
using TempusApi.Enums;

using var httpClient = new HttpClient();
var client = new TempusClient(httpClient);

var demo = await client.GetDemoInfoAsync(2294289);
var records = await client.GetTopZonedTimes("jump_beef", ZoneType.Map, 1, limit: 1);
```

Rate limiting
- The API enforces rate limits; 429 responses are handled using Retry-After headers.
- Configure pacing/retries with `TempusClientOptions`:

```csharp
var options = new TempusClientOptions
{
    MinimumRequestInterval = TimeSpan.FromMilliseconds(200),
    MaxRetryCount = 5
};

var client = new TempusClient(new HttpClient(), options);
```

Notes
- Use a singleton `TempusClient` for shared rate-limit state.
- `RecordInfoShort.DemoInfo` binds demo URL/ID when returned by the API.
