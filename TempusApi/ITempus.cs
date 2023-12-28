using System.Collections.Generic;
using System.Threading.Tasks;
using TempusApi.Models;
using TempusApi.Models.DetailedMapList;
using TempusApi.Models.PlayerStats;
using TempusApi.Models.Rank;
using TempusApi.Models.Responses;

namespace TempusApi;

public interface ITempus
{
    #region Activity
    
    /// <summary>
    /// /activity
    /// Returns recent records and top times.
    /// </summary>
    Task<RecentActivityModel> GetRecentActivityAsync();

    #endregion

    #region Demos

    /// <summary>
    /// /demos/id/{demoId}/overview
    /// Returns a demo overview.
    /// </summary>
    /// <param name="demoId">The demo ID. A working example value is 2294289.</param>
    Task<ServerDemoFullOverview> GetDemoInfoAsync(long demoId);

    #endregion

    #region Maps

    /// <summary>
    /// /maps/detailedList
    /// List maps on Tempus, with detailed information
    /// </summary>
    Task<List<DetailedMapOverviewModel>> GetDetailedMapListAsync();
    
    /// <summary>
    /// /maps/id/{mapId}/fullOverview
    /// Get information on a map by its ID
    /// </summary>
    /// <param name="mapId">The map ID. A working example value is 1.</param>
    Task<MapFullOverviewModel> GetFullMapOverviewAsync(long mapId);
    
    /// <summary>
    /// /maps/id/{mapId}/fullOverview2
    /// Get more information on a map by its ID
    /// </summary>
    /// <param name="mapId">The map ID. A working example value is 1.</param>
    Task<object> GetFullMapOverview2Async(long mapId);
    
    /// <summary>
    /// /maps/id/{mapId}/zones/typeindex/{zoneType}/{zoneIndex}/records/list
    /// List records and get info for a zone
    /// </summary>
    /// <param name="mapId">The map ID. A working example value is 136.</param>
    /// <param name="zoneType">The zone type. Working values include "map", "course", "bonus", and "trick".</param>
    /// <param name="zoneIndex">The zone index, starting from 1. This number is referred to in names such as "bonus 1" and "course 3". For map zone records, it is always 1.</param>
    /// <param name="limit">The number of records to return. The default is 50.</param>
    /// <param name="start">The record to start at. The default is 1.</param>
    /// <param name="sort">The field to sort on the. Working value is "duration"</param>
    /// <param name="direction">The direction to sort. Working values are "ascending"</param>
    Task<ZonedRecordsModel> GetTopZonedTimes(long mapId, string zoneType, int zoneIndex = 1, int? limit = null, int? start = null, string sort = null, string direction = null);

    /// <summary>
    /// /maps/id/{mapId}/zones/typeindex/{zoneType}/{zoneIndex}/records/player/{playerId}/{class}
    /// Get zone information and information about a player's completion, if it exists
    /// </summary>
    /// <param name="mapId">The map ID. A working example value is 136.</param>
    /// <param name="zoneType">The zone type. Working values include "map", "course", "bonus", and "trick".</param>
    /// <param name="zoneIndex">The zone index, starting from 1. This number is referred to in names such as "bonus 1" and "course 3". For map zone records, it is always 1.</param>
    /// <param name="playerId">The player ID.</param>
    /// <param name="playerClass">The class. 3 is soldier, 4 is demoman.</param>
    Task<PersonalRecordsModel> GetPersonalRecordAsync(long mapId, string zoneType, int zoneIndex, long playerId, int playerClass);
    
    /// <summary>
    /// /maps/list
    /// List maps on Tempus
    /// </summary>
    Task<List<ShortMapInfoModel>> GetMapListAsync();

    /// <summary>
    /// /maps/name/{mapName}/fullOverview
    /// Get information on a map by its ID
    /// </summary>
    /// <param name="mapName">The map's name. A working example value is "jump_beef".</param>
    Task<MapFullOverviewModel> GetFullMapOverviewAsync(string mapName);
    
    /// <summary>
    /// /maps/name/{mapName}/fullOverview2
    /// Get more information on a map by its ID
    /// </summary>
    /// <param name="mapName">The map's name. A working example value is "jump_beef".</param>
    Task<object> GetFullMapOverview2Async(string mapName);
    
    /// <summary>
    /// /maps/name/{mapName}/wrs
    /// Get world record run data for a map
    /// </summary>
    /// <param name="mapName">The map name. A working example value is "jump_beef".</param>
    Task<object> GetWorldRecordsDataAsync(string mapName);
    
    /// <summary>
    /// /maps/name/{mapName}/zones/typeindex/{zoneType}/{zoneIndex}/records/list
    /// List records and get info for a zone
    /// </summary>
    /// <param name="mapName">The map name. A working example value is "jump_beef".</param>
    /// <param name="zoneType">The zone type. Working values include "map", "course", "bonus", and "trick".</param>
    /// <param name="zoneIndex">The zone index, starting from 1. This number is referred to in names such as "bonus 1" and "course 3". For map zone records, it is always 1.</param>
    /// <param name="limit">The number of records to return. The default is 50.</param>
    /// <param name="start">The record to start at. The default is 1.</param>
    /// <param name="sort">The field to sort on the. Working value is "duration"</param>
    /// <param name="direction">The direction to sort. Working values are "ascending"</param>
    Task<ZonedRecordsModel> GetTopZonedTimes(string mapName, string zoneType, int zoneIndex = 1, int? limit = null, int? start = null, string sort = null, string direction = null);
    
    /// <summary>
    /// /maps/name/{mapName}/zones/typeindex/{zoneType}/{zoneIndex}/records/player/{playerId}/{class}
    /// Get zone information and information about a player's completion, if it exists
    /// </summary>
    /// <param name="mapName">The map name. A working example value is "jump_beef".</param>
    /// <param name="zoneType">The zone type. Working values include "map", "course", "bonus", and "trick".</param>
    /// <param name="zoneIndex">The zone index, starting from 1. This number is referred to in names such as "bonus 1" and "course 3". For map zone records, it is always 1.</param>
    /// <param name="playerId">The player ID.</param>
    /// <param name="playerClass">The class. 3 is soldier, 4 is demoman.</param>
    Task<PersonalRecordsModel> GetPersonalRecordAsync(string mapName, string zoneType, int zoneIndex, string playerId, int playerClass);

    #endregion

    #region Players

    /// <summary>
    /// /players/id/{playerId}/rank
    /// Get information about a player's rank
    /// </summary>
    /// <param name="playerId">The player ID.</param>
    Task<Rank> GetPlayerRankAsync(long playerId);

    /// <summary>
    /// /players/id/{playerId}/info
    /// Get basic player information
    /// </summary>
    /// <param name="playerId">The player ID.</param>
    Task<object> GetPlayerInfoAsync(long playerId);

    /// <summary>
    /// /players/id/{playerId}/stats
    /// Get player statistics
    /// </summary>
    /// <param name="playerId">The player ID.</param>
    Task<PlayerStatsModel> GetPlayerStatsAsync(long playerId);

    #endregion
    
    #region Ranks
    
    /// <summary>
    /// /ranks/class/{class}
    /// List the top 50 players for the given class
    /// </summary>
    /// <param name="class">The class. 3 is soldier, 4 is demoman.</param>
    /// <param name="start">Which rank to start the 50 from, default is 1</param>
    Task<RanksOverviewModel> GetRanksAsync(int @class, int? start = null);
    
    /// <summary>
    /// /ranks/overall
    /// List the top 50 players by overall ranking
    /// </summary>
    /// <param name="start">Which rank to start the 50 from, default is 1</param>
    Task<RanksOverviewModel> GetTopOverallRanksAsync(int? start = null);
    
    #endregion
    
    #region Records

    /// <summary>
    /// /records/id/{recordId}/overview
    /// Get a record (run) overview by recordId
    /// </summary>
    /// <param name="recordId"></param>
    Task<RunInfoModel> GetRecordAsync(long recordId);

    #endregion
    
    #region Search

    /// <summary>
    /// /search/playersAndMaps/{nameQuery}
    /// Search for players and maps by name
    /// </summary>
    /// <param name="query">The search query. Case insensitive. Up to 20 players and 5 maps are returned.</param>
    Task<PlayerMapSearchResult> GetSearchResultAsync(string query);

    #endregion

    #region Servers

    /// <summary>
    /// /servers/{serverId}/demos
    /// List up to 50 most recent demos for a server
    /// </summary>
    /// <param name="serverId">The server ID.</param>
    Task<List<ServerDemoModel>> GetServerDemosAsync(long serverId);

    /// <summary>
    /// /servers/statusList
    /// List game server statuses
    /// </summary>
    Task<List<ServerStatusModel>> GetServersStatusesAsync();

    #endregion

    #region Zones
    
    /// <summary>
    /// /zones/id/{zoneId}/records/list
    /// List records for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID. A working example value is 1.</param>
    /// <param name="limit">Max number of records to return. 0 is unlimited.</param>
    /// <param name="start">The record to start at. The default is 1.</param>
    /// <param name="sort">The field to sort on the. Working value is "duration"</param>
    /// <param name="direction">The direction to sort. Working values are "ascending"</param>
    Task<ZonedRecordsModel> GetTopZonedTimes(long zoneId, long? limit = null, int? start = null, string sort = null, string direction = null);

    #endregion
}