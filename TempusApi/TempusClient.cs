using System;
using System.Collections.Generic;
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

    public TempusClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
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
        => await _httpClient.GetFromJsonAsync<RecentActivityModel>("activity", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<ServerDemoFullOverview> GetDemoInfoAsync(long demoId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<ServerDemoFullOverview>($"demos/id/{demoId}/overview", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<List<DetailedMapOverviewModel>> GetDetailedMapListAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<List<DetailedMapOverviewModel>>("maps/detailedList", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<MapFullOverviewModel> GetFullMapOverviewAsync(long mapId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<MapFullOverviewModel>($"maps/id/{mapId}/fullOverview", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<FullMapOverview2> GetFullMapOverview2Async(long mapId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<FullMapOverview2>($"maps/id/{mapId}/fullOverview2", _jsonSerializerOptions, cancellationToken: cancellationToken);

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
        
        return await _httpClient.GetFromJsonAsync<ZonedRecordsModel>(url + uriBuilder.Query, _jsonSerializerOptions, cancellationToken: cancellationToken);
    }

    public async Task<PersonalRecordsModel> GetPersonalRecordAsync(long mapId, ZoneType zoneType, int zoneIndex, long playerId, Class playerClass,
        CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<PersonalRecordsModel>($"maps/id/{mapId}/zones/typeindex/{zoneType.ToString().ToLower()}/{zoneIndex}/records/player/{playerId}/{playerClass}", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<List<ShortMapInfoModel>> GetMapListAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<List<ShortMapInfoModel>>("maps/list", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<MapFullOverviewModel> GetFullMapOverviewAsync(string mapName, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<MapFullOverviewModel>($"maps/name/{mapName}/fullOverview", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<FullMapOverview2> GetFullMapOverview2Async(string mapName, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<FullMapOverview2>($"maps/name/{mapName}/fullOverview2", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<WorldRecordsData> GetWorldRecordsDataAsync(string mapName, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<WorldRecordsData>($"maps/name/{mapName}/wrs", _jsonSerializerOptions, cancellationToken: cancellationToken);

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
        
        return await _httpClient.GetFromJsonAsync<ZonedRecordsModel>(url + uriBuilder.Query, _jsonSerializerOptions, cancellationToken: cancellationToken);
    }

    public async Task<PersonalRecordsModel> GetPersonalRecordAsync(string mapName, ZoneType zoneType, int zoneIndex, string playerId, Class playerClass,
        CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<PersonalRecordsModel>($"maps/name/{mapName}/zones/typeindex/{zoneType.ToString().ToLower()}/{zoneIndex}/records/player/{playerId}/{(int)playerClass}", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<Rank> GetPlayerRankAsync(long playerId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<Rank>($"players/id/{playerId}/rank", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<PlayerInfo> GetPlayerInfoAsync(long playerId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<PlayerInfo>($"players/id/{playerId}/info", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<PlayerStatsModel> GetPlayerStatsAsync(long playerId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<PlayerStatsModel>($"players/id/{playerId}/stats", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<RanksOverviewModel> GetRanksAsync(Class @class, int? start = null,
        CancellationToken cancellationToken = default)
    {
        var url = $"ranks/class/{(int)@class}";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (start != null) queryParams["start"] = start.ToString();

        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await _httpClient.GetFromJsonAsync<RanksOverviewModel>(url + uriBuilder.Query, _jsonSerializerOptions, cancellationToken: cancellationToken);
    }

    public async Task<RanksOverviewModel> GetTopOverallRanksAsync(int? start = null, CancellationToken cancellationToken = default)
    {
        var url = "ranks/overall";
        
        var uriBuilder = new UriBuilder(url);
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (start != null) queryParams["start"] = start.ToString();

        uriBuilder.Query = queryParams.ToString() ?? string.Empty;
        
        return await _httpClient.GetFromJsonAsync<RanksOverviewModel>(url + uriBuilder.Query, _jsonSerializerOptions, cancellationToken: cancellationToken);
    }

    public async Task<RunInfoModel> GetRecordAsync(long recordId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<RunInfoModel>($"records/id/{recordId}/overview", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<PlayerMapSearchResult> GetSearchResultAsync(string query, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<PlayerMapSearchResult>($"search/playersAndMaps/{query}", _jsonSerializerOptions, cancellationToken: cancellationToken);

    public async Task<List<ServerDemoModel>> GetServerDemosAsync(long serverId, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<List<ServerDemoModel>>($"servers/{serverId}/demos", _jsonSerializerOptions, cancellationToken: cancellationToken);
    public async Task<List<ServerStatusModel>> GetServersStatusesAsync(CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<List<ServerStatusModel>>("servers/statusList", _jsonSerializerOptions, cancellationToken: cancellationToken);

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
        
        return await _httpClient.GetFromJsonAsync<ZonedRecordsModel>(url + uriBuilder.Query, _jsonSerializerOptions, cancellationToken: cancellationToken);
    }
}