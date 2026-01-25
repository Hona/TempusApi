using System;

namespace TempusApi;

public sealed class TempusClientOptions
{
    public TimeSpan MinimumRequestInterval { get; set; } = TimeSpan.FromSeconds(1);
    public int MaxRetryCount { get; set; } = 5;
}
