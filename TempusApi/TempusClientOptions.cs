using System;

namespace TempusApi;

public sealed class TempusClientOptions
{
    public TimeSpan MinimumRequestInterval { get; set; } = TimeSpan.FromMilliseconds(200);
    public int MaxRetryCount { get; set; } = 5;
}
