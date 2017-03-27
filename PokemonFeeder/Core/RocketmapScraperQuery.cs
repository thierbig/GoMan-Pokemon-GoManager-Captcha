using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Goman_Plugin.Helpers;
using Newtonsoft.Json;
using PokemonFeeder.Model;

namespace PokemonFeeder.Core
{
    public class RocketmapScraperQuery
    {
        public Uri RocketMapUri { get; set; }
        public int TotalScrapedPokemon { get; private set; }
        public string LastLog { get; set; }
        public int TimerInterval { get; set; } = 5000;

        [JsonConstructor]
        public RocketmapScraperQuery()
        {
        }
        public RocketmapScraperQuery(Uri rocketMapUri)
        {
            RocketMapUri = rocketMapUri;
        }

        private bool _enabled;

        public void Disable()
        {
            _enabled = false;
        }
        public void Enable()
        {
            _enabled = true;
            Task.Run(async () =>
            {
                while (_enabled)
                {
                    try
                    {
                        LastLog = "Started";
                        var rocketmapResponse = await SendRequest();
                        if (rocketmapResponse.Success && rocketmapResponse.Data != null && rocketmapResponse.Data.Pokemons != null && rocketmapResponse.Data.Pokemons.Count > 0)
                        {
                            LastLog = $"Successful scrapped {rocketmapResponse?.Data?.Pokemons.Count}";
                            TotalScrapedPokemon += rocketmapResponse.Data.Pokemons.Count;
                            var toRemove = new List<PokemonLocationInformation>();
                            foreach (var pokemonLocationInformation in rocketmapResponse.Data.Pokemons)
                            {
                                try
                                {
                                    pokemonLocationInformation.LastModified =
                                        pokemonLocationInformation.LastModified == null
                                            ? DateTime.UtcNow.ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture)
                                            : UnixTimeStampToDateTime(
                                                    long.Parse(pokemonLocationInformation.LastModified) / 1000)
                                                .ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture);

                                    pokemonLocationInformation.DisappearTime =
                                        pokemonLocationInformation.DisappearTime == null
                                            ? DateTime.UtcNow.ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture)
                                            : UnixTimeStampToDateTime(
                                                    long.Parse(pokemonLocationInformation.DisappearTime) / 1000)
                                                .ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture);

                                    if (pokemonLocationInformation.Move1 == null) pokemonLocationInformation.Move1 = 0;
                                    if (pokemonLocationInformation.Move2 == null) pokemonLocationInformation.Move2 = 0;
                                    if (pokemonLocationInformation.Iv != null) continue;

                                    if (pokemonLocationInformation.Attack == null ||
                                        pokemonLocationInformation.Defense == null ||
                                        pokemonLocationInformation.Stamina == null)
                                    {
                                        pokemonLocationInformation.Attack = 0;
                                        pokemonLocationInformation.Defense = 0;
                                        pokemonLocationInformation.Stamina = 0;
                                        pokemonLocationInformation.Iv = 0;
                                        continue;
                                    }

                                    var iv =
                                        (double)
                                        (pokemonLocationInformation.Attack + pokemonLocationInformation.Defense +
                                         pokemonLocationInformation.Stamina) / 45 * 100;

                                    pokemonLocationInformation.Iv = iv;
                                }
                                catch (Exception e)
                                {
                                    toRemove.Add(pokemonLocationInformation);
                                    LastLog = $"ERROR: {e?.Message} \n {e?.StackTrace}";
                                }

                            }
                            foreach (var pokemonLocationInformation in toRemove)
                            {
                                rocketmapResponse?.Data?.Pokemons.Remove(pokemonLocationInformation);
                            }

                            var uploadResults = await Execute(rocketmapResponse.Data);

                            LastLog = !uploadResults.Success
                                ? $"Failed to upload: {uploadResults?.Error.Message} \n {uploadResults?.Error.StackTrace}"
                                : $"Successful uploaded {rocketmapResponse?.Data?.Pokemons.Count}";

                        }
                        else
                            LastLog =
                                $"ERROR: {rocketmapResponse?.Error.Message} \n {rocketmapResponse?.Error.StackTrace}";
                    }
                    catch (Exception e)
                    {
                        LastLog = $"Disabled: {e?.Message} \n {e?.StackTrace}";
                        // _disabled = true;
                    }

                    await Task.Delay(TimerInterval);
                    Thread.Sleep(TimerInterval);
                }




            });
        }

        private bool _disabled = false;
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            return dtDateTime;
        }

        public async Task<MethodResult<string>> Execute(RocketmapResponse rocketmapResponse)
        {
            var methodResults = new MethodResult<string>();
            if (rocketmapResponse.Pokemons.Count <= 0) return methodResults;
            try
            {
                var jsonString = JsonConvert.SerializeObject(rocketmapResponse.Pokemons);
                using (var wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var asd = await wc.UploadStringTaskAsync(new Uri("http://144.217.215.59:8080/api/pokeadd.php"), jsonString);
                    //using (var sw =  new StreamWriter($"{RocketMapUri.Host}.txt"))
                    //{
                    //    await sw.WriteLineAsync(asd);
                    //}

                    methodResults.Success = true;
                }
            }
            catch (Exception e)
            {
                methodResults.Success = false;
                methodResults.Error = e;
            }

            return methodResults;
        }

        public async Task<MethodResult<RocketmapResponse>> SendRequest()
        {
            var methodResults = new MethodResult<RocketmapResponse>();

                var handler = new ClearanceHandler();

                var client = new HttpClient(handler);

                try
                {
                    var responseString = await client.GetStringAsync(GetUrlWithParameters());
                    var responsePokemon = JsonConvert.DeserializeObject<RocketmapResponse>(responseString);
                    methodResults.Data = responsePokemon;
                    methodResults.Success = true;
                    client.Dispose();
                }
                catch (AggregateException ex) when (ex.InnerException is CloudFlareClearanceException)
                {
                    methodResults.Success = false;
                    methodResults.Error = ex.InnerException;
                }

                


            return methodResults;
        }
        public void Reset()
        {
            RequestOnlyNewPokemon = false;
        }

        private long GetUnixTimeStampNow()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
        private string GetUrlWithParameters()
        {
            var unixTimestamp = GetUnixTimeStampNow();
            CurrentTimestampUtc = unixTimestamp;

            if (!RequestOnlyNewPokemon)
                InitialTimestampUtc = unixTimestamp;

            Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"timestamp", CurrentTimestampUtc.ToString()},
                    {"pokemon", RequestPokemon.ToString()},
                    {"lastpokemon", RequestOnlyNewPokemon.ToString()},
                    {"pokestops", RequestPokestops.ToString()},
                    {"luredonly", RequestOnlyLuredPokeStops.ToString()},
                    {"gyms", RequestGyms.ToString()},
                    {"scanned", NotSureScanned.ToString()},
                    {"spawnpoints", NotSureSpawnPoints.ToString()},
                    {"swLat", SwLat.ToString()},
                    {"swLng", SwLng.ToString()},
                    {"neLat", NeLat.ToString()},
                    {"neLng", NeLng.ToString()},
                    {"oSwLat", OSwLat.ToString()},
                    {"oSwLng", OSwLng.ToString()},
                    {"oNeLat", ONeLat.ToString()},
                    {"oNeLng", ONeLng.ToString()},
                    {"reids", Reids.ToString()},
                    {"eids", Eids.ToString()},
                    {"_", InitialTimestampUtc.ToString()}
                };

            if (!RequestOnlyNewPokemon)
                RequestOnlyNewPokemon = true;


            return string.Format(RocketMapUri + "raw_data?{0}", string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}")).ToLower());
        }
        [JsonIgnore]
        private long CurrentTimestampUtc { get; set; }
        [JsonIgnore]
        private bool RequestPokemon { get; set; } = true;
        [JsonIgnore]
        private bool RequestOnlyNewPokemon { get; set; } = false;
        [JsonIgnore]
        private bool RequestPokestops { get; set; } = false;
        [JsonIgnore]
        private bool RequestOnlyLuredPokeStops { get; set; } = false;
        [JsonIgnore]
        private bool RequestGyms { get; set; } = false;
        [JsonIgnore]
        private bool NotSureScanned { get; set; } = false;
        [JsonIgnore]
        private bool NotSureSpawnPoints { get; set; } = false;
        [JsonIgnore]
        private int SwLat { get; set; } = -90;
        [JsonIgnore]
        private int SwLng { get; set; } = -180;
        [JsonIgnore]
        private int NeLat { get; set; } = 90;
        [JsonIgnore]
        private int NeLng { get; set; } = 180;
        [JsonIgnore]
        private int OSwLat { get; set; } = -90;
        [JsonIgnore]
        private int OSwLng { get; set; } = -180;
        [JsonIgnore]
        private int ONeLat { get; set; } = 90;
        [JsonIgnore]
        private int ONeLng { get; set; } = 180;
        [JsonIgnore]
        private string Reids { get; set; } = "";
        [JsonIgnore]
        private string Eids { get; set; } = "";
        [JsonIgnore]
        private long InitialTimestampUtc { get; set; }
    }
}

