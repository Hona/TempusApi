using TempusApi.Enums;

namespace TempusApi.Tests;

public class TempusApiIntegrationTests
{
    private const string KnownMapName = "jump_beef";
    private const long KnownDemoId = 2294289;

    [Fact]
    public async Task GetDemoInfoAsync_ReturnsOverview()
    {
        using var httpClient = new HttpClient();
        var client = new TempusClient(httpClient);

        var demo = await client.GetDemoInfoAsync(KnownDemoId);

        Assert.NotNull(demo);
        Assert.NotNull(demo.Overview);
        Assert.Equal(KnownDemoId, demo.Overview.Id);
        Assert.False(string.IsNullOrWhiteSpace(demo.Overview.Url));
    }

    [Fact]
    public async Task GetTopZonedTimes_MapsIncludeDemoInfo()
    {
        using var httpClient = new HttpClient();
        var client = new TempusClient(httpClient);

        var records = await client.GetTopZonedTimes(KnownMapName, ZoneType.Map, 1, limit: 1);
        var soldierRuns = records.Runs.SoldierRuns;

        Assert.NotNull(records);
        Assert.NotNull(soldierRuns);
        Assert.NotEmpty(soldierRuns);

        var demoInfo = soldierRuns[0].DemoInfo;
        Assert.NotNull(demoInfo);
        Assert.True(demoInfo.Id > 0);
        Assert.False(string.IsNullOrWhiteSpace(demoInfo.Url));
    }
}
