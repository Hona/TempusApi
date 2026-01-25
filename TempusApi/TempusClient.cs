using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TempusApi.Enums;
using TempusApi.Models;
using TempusApi.Models.DetailedMapList;
using TempusApi.Models.PlayerStats;
using TempusApi.Models.Rank;
using TempusApi.Models.Responses;
using PlayerInfo = TempusApi.Models.Responses.PlayerInfo;

namespace TempusApi;

public class TempusClient : ITempusClient
{
    private readonly HttpClient _httpClient;
    private readonly TempusClientOptions _options;
    private readonly SemaphoreSlim _rateLimitLock = new(1, 1);
    private DateTimeOffset _nextRequestUtc = DateTimeOffset.MinValue;

    public TempusClient(HttpClient httpClient, TempusClientOptions? options = null)
    {
        _httpClient = httpClient;
        _options = options ?? new TempusClientOptions();
        
        _httpClient.BaseAddress = new Uri("https://tempus2.xyz/api/v0/");
    }

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower)
        }
    };
    
    public async Task<RecentActivityModel> GetRecentActivityAsync(CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<RecentActivityModel>("activity", cancellationToken);

    public async Task<ServerDemoFullOverview> GetDemoInfoAsync(long demoId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<ServerDemoFullOverview>($"demos/id/{demoId}/overview", cancellationToken);

    public async Task<List<DetailedMapOverviewModel>> GetDetailedMapListAsync(CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<List<DetailedMapOverviewModel>>("maps/detailedList", cancellationToken);

    public async Task<MapFullOverviewModel> GetFullMapOverviewAsync(long mapId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<MapFullOverviewModel>($"maps/id/{mapId}/fullOverview", cancellationToken);

    public async Task<FullMapOverview2> GetFullMapOverview2Async(long mapId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<FullMapOverview2>($"maps/id/{mapId}/fullOverview2", cancellationToken);

    public async Task<ZonedRecordsModel> GetTopZonedTimes(long mapId, ZoneType zoneType, int zoneIndex = 1,
        int? limit = null, int? start = null,
        string sort = null, SortDirection? direction = null, CancellationToken cancellationToken = default)
    {
        var url = $"maps/id/{mapId}/zones/typeindex/{zoneType.ToString().ToLower()}/{zoneIndex}/records/list";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (limit != null) queryParams["limit"] = limit.ToString();
        if (start != null) queryParams["start"] = start.ToString();
        if (sort != null) queryParams["sort"] = sort;
        if (direction != null) queryParams["direction"] = direction.ToString();

        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await GetFromJsonAsync<ZonedRecordsModel>(url + uriBuilder.Query, cancellationToken);
    }

    public async Task<PersonalRecordsModel> GetPersonalRecordAsync(long mapId, ZoneType zoneType, int zoneIndex, long playerId, Class playerClass,
        CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<PersonalRecordsModel>($"maps/id/{mapId}/zones/typeindex/{zoneType.ToString().ToLower()}/{zoneIndex}/records/player/{playerId}/{playerClass}", cancellationToken);

    public async Task<List<ShortMapInfoModel>> GetMapListAsync(CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<List<ShortMapInfoModel>>("maps/list", cancellationToken);

    public async Task<MapFullOverviewModel> GetFullMapOverviewAsync(string mapName, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<MapFullOverviewModel>($"maps/name/{mapName}/fullOverview", cancellationToken);

    public async Task<FullMapOverview2> GetFullMapOverview2Async(string mapName, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<FullMapOverview2>($"maps/name/{mapName}/fullOverview2", cancellationToken);

    public async Task<WorldRecordsData> GetWorldRecordsDataAsync(string mapName, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<WorldRecordsData>($"maps/name/{mapName}/wrs", cancellationToken);

    public async Task<ZonedRecordsModel> GetTopZonedTimes(string mapName, ZoneType zoneType, int zoneIndex = 1, int? limit = null, int? start = null,
        string sort = null, SortDirection? direction = null, CancellationToken cancellationToken = default)
    {
        var url = $"maps/name/{mapName}/zones/typeindex/{zoneType.ToString().ToLower()}/{zoneIndex}/records/list";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (limit != null) queryParams["limit"] = limit.ToString();
        if (start != null) queryParams["start"] = start.ToString();
        if (sort != null) queryParams["sort"] = sort;
        if (direction != null) queryParams["direction"] = direction.ToString();

        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await GetFromJsonAsync<ZonedRecordsModel>(url + uriBuilder.Query, cancellationToken);
    }

    public async Task<PersonalRecordsModel> GetPersonalRecordAsync(string mapName, ZoneType zoneType, int zoneIndex, string playerId, Class playerClass,
        CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<PersonalRecordsModel>($"maps/name/{mapName}/zones/typeindex/{zoneType.ToString().ToLower()}/{zoneIndex}/records/player/{playerId}/{(int)playerClass}", cancellationToken);

    public async Task<Rank> GetPlayerRankAsync(long playerId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<Rank>($"players/id/{playerId}/rank", cancellationToken);

    public async Task<PlayerInfo> GetPlayerInfoAsync(long playerId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<PlayerInfo>($"players/id/{playerId}/info", cancellationToken);

    public async Task<PlayerStatsModel> GetPlayerStatsAsync(long playerId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<PlayerStatsModel>($"players/id/{playerId}/stats", cancellationToken);

    public async Task<RanksOverviewModel> GetRanksAsync(Class @class, int? start = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"ranks/class/{(int)@class}";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (start != null) queryParams["start"] = start.ToString();

        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await GetFromJsonAsync<RanksOverviewModel>(url + uriBuilder.Query, cancellationToken);
    }

    public async Task<RanksOverviewModel> GetTopOverallRanksAsync(int? start = null, CancellationToken cancellationToken = default)
    {
        var url = "ranks/overall";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (start != null) queryParams["start"] = start.ToString();

        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await GetFromJsonAsync<RanksOverviewModel>(url + uriBuilder.Query, cancellationToken);
    }

    public async Task<RunInfoModel> GetRecordAsync(long recordId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<RunInfoModel>($"records/id/{recordId}/overview", cancellationToken);

    public async Task<PlayerMapSearchResult> GetSearchResultAsync(string query, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<PlayerMapSearchResult>($"search/playersAndMaps/{query}", cancellationToken);

    public async Task<List<ServerDemoModel>> GetServerDemosAsync(long serverId, CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<List<ServerDemoModel>>($"servers/{serverId}/demos", cancellationToken);
    public async Task<List<ServerStatusModel>> GetServersStatusesAsync(CancellationToken cancellationToken = default)
        => await GetFromJsonAsync<List<ServerStatusModel>>("servers/statusList", cancellationToken);

    public async Task<ZonedRecordsModel> GetTopZonedTimes(long zoneId, long? limit = null, int? start = null, string sort = null,
        SortDirection? direction = null, CancellationToken cancellationToken = default)
    {
        var url = $"zones/id/{zoneId}/records/list";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (limit != null) queryParams["limit"] = limit.ToString();
        if (start != null) queryParams["start"] = start.ToString();
        if (sort != null) queryParams["sort"] = sort;
        if (direction != null) queryParams["direction"] = direction.ToString();

        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await GetFromJsonAsync<ZonedRecordsModel>(url + uriBuilder.Query, cancellationToken);
    }

    public async Task<Dictionary<long, SteamProfile>> GetSteamProfilesAsync(IEnumerable<long> playerIds, CancellationToken cancellationToken = default)
    {
        var url = "steamavatars";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);
        
        queryParams["steamids"] = string.Join(",", playerIds);
        
        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await GetFromJsonAsync<Dictionary<long, SteamProfile>>(url + uriBuilder.Query, cancellationToken);
    }

    private async Task<T> GetFromJsonAsync<T>(string url, CancellationToken cancellationToken)
    {
        for (var attempt = 0; attempt <= _options.MaxRetryCount; attempt++)
        {
            await WaitForRequestSlotAsync(cancellationToken);

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await ApplyRetryAfterAsync(response, cancellationToken);
                continue;
            }

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions, cancellationToken);
            if (result is null)
            {
                throw new InvalidOperationException("Response body was empty.");
            }

            return result;
        }

        throw new HttpRequestException("Exceeded retry limit due to rate limiting.");
    }

    private async Task WaitForRequestSlotAsync(CancellationToken cancellationToken)
    {
        await _rateLimitLock.WaitAsync(cancellationToken);
        try
        {
            var now = DateTimeOffset.UtcNow;
            if (_nextRequestUtc > now)
            {
                await Task.Delay(_nextRequestUtc - now, cancellationToken);
            }

            if (_options.MinimumRequestInterval > TimeSpan.Zero)
            {
                var next = DateTimeOffset.UtcNow + _options.MinimumRequestInterval;
                if (next > _nextRequestUtc)
                {
                    _nextRequestUtc = next;
                }
            }
        }
        finally
        {
            _rateLimitLock.Release();
        }
    }

    private async Task ApplyRetryAfterAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        var retryDelay = GetRetryAfterDelay(response);
        if (retryDelay == null)
        {
            return;
        }

        if (retryDelay < TimeSpan.Zero)
        {
            retryDelay = TimeSpan.Zero;
        }

        await _rateLimitLock.WaitAsync(cancellationToken);
        try
        {
            var target = DateTimeOffset.UtcNow + retryDelay.Value;
            if (target > _nextRequestUtc)
            {
                _nextRequestUtc = target;
            }
        }
        finally
        {
            _rateLimitLock.Release();
        }
    }

    private static TimeSpan? GetRetryAfterDelay(HttpResponseMessage response)
    {
        var retryAfter = response.Headers.RetryAfter;
        if (retryAfter == null)
        {
            return null;
        }

        if (retryAfter.Delta.HasValue)
        {
            return retryAfter.Delta.Value;
        }

        if (retryAfter.Date.HasValue)
        {
            return retryAfter.Date.Value - DateTimeOffset.UtcNow;
        }

        return null;
    }
}
