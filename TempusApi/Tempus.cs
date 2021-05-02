using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TempusApi.Models;
using TempusApi.Models.Activity;
using TempusApi.Models.DetailedMapList;
using TempusApi.Models.PlayerStats;
using TempusApi.Models.Rank;
using TempusApi.Models.Responses;

namespace TempusApi
{
    public class Tempus
    {
        private static readonly HttpClient HttpClient = new()
        {
            BaseAddress = new Uri("https://tempus.xyz")
        };

        private List<DetailedMapOverviewModel> _mapList;

        private List<string> MapNameList { get; set; }

        public async Task<List<DetailedMapOverviewModel>> GetDetailedMapListAsync(bool allowCached = true)
        {
            if (!allowCached)
            {
                var mapList = await InternalGetDetailedMapListAsync();
                _mapList = mapList;
                return mapList;
            }

            if (_mapList != null &&
                (_mapList != null || _mapList.Count != 0))
                return _mapList;

            await UpdateMapListAsync();
            return _mapList;
        }

        private static string GetFullApiPath(string partial) => "/api" + partial;

        private static async Task<T> GetResponseAsync<T>(string request)
        {
            var fullPath = GetFullApiPath(request);

            try
            {
                var response = await HttpClient.GetAsync(fullPath)
                    .ConfigureAwait(false);

                if (!response.IsSuccessStatusCode) throw new Exception("Couldn't get Tempus API request: " + fullPath);

                object stringValue = await response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false);

                // If T is a string, don't deserialize
                return typeof(T) == typeof(string) ? (T) stringValue : JsonConvert.DeserializeObject<T>((string) stringValue);
            }
            catch (Exception e)
            {
                throw new Exception("Failed on: " + fullPath, e);
            }
        }

        public async Task<MapFullOverviewModel> GetFullMapOverViewAsync(string map)
        {
            if (map == null) return null;

            var overview = await GetResponseAsync<MapFullOverviewModel>($"/maps/name/{await ParseMapNameAsync(map)}/fullOverview")
                .ConfigureAwait(false);
            return overview;
        }

        public async Task<ZonedRecordsModel> GetTopZonedTimes(string mapName, string zoneType, int zoneIndex = 1)
            => await GetResponseAsync<ZonedRecordsModel>($"/maps/name/{mapName}/zones/typeindex/{zoneType}/{zoneIndex}/records/list")
                .ConfigureAwait(false);

        public async Task<RecentActivityModel> GetRecentActivityAsync()
        {
            var activity = await GetResponseAsync<RecentActivityModel>("/activity")
                .ConfigureAwait(false);
            var worldRecordActivity = new List<TempusRecordBase>();

            // We are basically excluding the map top times
            worldRecordActivity.AddRange(activity.BonusRecords);
            worldRecordActivity.AddRange(activity.CourseRecords);
            worldRecordActivity.AddRange(activity.MapRecords);


            return activity;
        }

        public async Task<PlayerMapSearchResult> GetSearchResultAsync(string query)
            => await GetResponseAsync<PlayerMapSearchResult>($"/search/playersAndMaps/{HttpUtility.UrlEncode(query)}")
                .ConfigureAwait(false);

        public async Task<List<ServerStatusModel>> GetServerStatusAsync()
            => await GetResponseAsync<List<ServerStatusModel>>("/servers/statusList")
                .ConfigureAwait(false);

        public async Task<List<ShortMapInfoModel>> GetMapListAsync()
            => await GetResponseAsync<List<ShortMapInfoModel>>("/maps/list")
                .ConfigureAwait(false);

        private async Task<List<DetailedMapOverviewModel>> InternalGetDetailedMapListAsync()
            => await GetResponseAsync<List<DetailedMapOverviewModel>>("/maps/detailedList")
                .ConfigureAwait(false);

        public async Task<RanksOverviewModel> GetOverallRanksOverview()
            => await GetResponseAsync<RanksOverviewModel>("/ranks/overall")
                .ConfigureAwait(false);

        public async Task<RanksOverviewModel> GetDemomanRanksOverview()
            => await GetResponseAsync<RanksOverviewModel>("/ranks/class/4")
                .ConfigureAwait(false);

        public async Task<RanksOverviewModel> GetSoldierRanksOverview()
            => await GetResponseAsync<RanksOverviewModel>("/ranks/class/3")
                .ConfigureAwait(false);

        public async Task<Rank> GetUserRankAsync(string id)
            => await GetResponseAsync<Rank>($"/players/id/{id}/rank")
                .ConfigureAwait(false);

        public async Task<PlayerStatsModel> GetUserStatsAsync(string id)
            => await GetResponseAsync<PlayerStatsModel>($"/players/id/{id}/stats")
                .ConfigureAwait(false);

        public async Task<List<ServerDemoModel>> GetServerDemosAsync(int serverId)
            => await GetResponseAsync<List<ServerDemoModel>>($"/servers/{serverId}/demos")
                .ConfigureAwait(false);

        public async Task<ServerDemoFullOverview> GetDemoInfoAsync(int demoId)
            => await GetResponseAsync<ServerDemoFullOverview>($"/demos/id/{demoId}/overview")
                .ConfigureAwait(false);

        //RunInfoModel
        public async Task<RunInfoModel> GetRunInfoAsync(int runId)
            => await GetResponseAsync<RunInfoModel>($"/records/id/{runId}/overview")
                .ConfigureAwait(false);

        public async Task<PersonalRecordsModel> GetPersonalRecordAsync(string mapName, string zoneType, int zoneIndex,
            string playerId, int playerClass)
            => await GetResponseAsync<PersonalRecordsModel>(
                $"/maps/name/{mapName}/zones/typeindex/{zoneType}/{zoneIndex}/records/player/{playerId}/{playerClass}");

        public async Task<Dictionary<string, SteamProfile>> GetSteamAvatarsAsync(params string[] steamIds)
            => await GetResponseAsync<Dictionary<string, SteamProfile>>(
                $"/steamavatars?steamids={string.Join(",", steamIds)}");
        public async Task<string> ParseMapNameAsync(string map)
        {
            if (MapNameList == null ||
                MapNameList.Count == 0)
                await UpdateMapListAsync();

            if (string.IsNullOrWhiteSpace(map)) return string.Empty;
            map = map.ToLower();
            if (MapNameList.Contains(map)) return map;

            foreach (var mapName in MapNameList.Select(mapName => new
                {
                    mapName,
                    mapParts = mapName.Split('_')
                })
                .Where(x => x.mapParts.Any(mapPart => map == mapPart))
                .Select(x => x.mapName))
            {
                return mapName;
            }

            throw new Exception("Map not found");
        }

        private async Task UpdateMapListAsync()
        {
            var maps = await GetDetailedMapListAsync(false)
                .ConfigureAwait(false);
            _mapList = maps.OrderBy(x => x.Name)
                .ToList();
            MapNameList = maps.ConvertAll(x => x.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();
        }
    }
}