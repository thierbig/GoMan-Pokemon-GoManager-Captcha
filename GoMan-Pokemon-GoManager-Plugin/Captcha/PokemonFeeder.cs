using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Timers;
using GoMan.Helpers;
using GoPlugin.Events;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;

namespace GoMan.Captcha
{
    public class PokemonFeeder
    {
        private static readonly Timer Timer = new Timer(15000);
        public static HashSet<PokemonLocationInfo> PokemonDataInformation = new HashSet<PokemonLocationInfo>();
        static PokemonFeeder()
        {
            Timer.Elapsed += _timer_Elapsed;
            Timer.Enabled = true;
        }

        private static async void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PokemonDataInformation.Count == 0) return;

            List<PokemonLocationInfo> copiedList;
            lock (PokemonDataInformation)
            {
                copiedList = new List<PokemonLocationInfo>(PokemonDataInformation);
                PokemonDataInformation.Clear();
            }

            var jsonString = JsonConvert.SerializeObject(copiedList);
            var result = await GomanWebsiteHelper.TryUploadPokemon(new StringContent(jsonString, Encoding.UTF8, "application/json"));

            if (result.Success) return;
            lock (PokemonDataInformation)
                copiedList.ForEach(x => PokemonDataInformation.Add(x));
        }
    }



    public class PokemonLocationInfo
        {
            [JsonProperty("encounter_id")]
            private long EncounterId { get; set; }
            [JsonProperty("iv")]
            private double Iv { get; set; }
            [JsonProperty("cp")]
            private int Cp { get; set; }
            [JsonProperty("lat")]
            private double Latitude { get; set; }
            [JsonProperty("lon")]
            private double Longitude { get; set; }
            [JsonProperty("name")]
            private int PokemonName { get; set; }
            [JsonProperty("move1")]
            private int Move1 { get; set; }
            [JsonProperty("move2")]
            private int Move2 { get; set; }
            [JsonProperty("expiration")]
            private long ExpirationTime { get; set; }

            public PokemonLocationInfo(PokemonCaughtEventArgs e, double iv)
            {
                EncounterId = (long)e.MapPokemon.EncounterId;
                Iv = iv;
                Cp = e.Pokemon.Cp;
                Latitude = e.MapPokemon.Latitude;
                Longitude = e.MapPokemon.Longitude;
                PokemonName = (int)e.Pokemon.PokemonId;
                Move1 = (int)e.Pokemon.Move1;
                Move2 = (int)e.Pokemon.Move2;
                ExpirationTime = e.MapPokemon.ExpirationTimestampMs;
            }

            private bool Equals(PokemonLocationInfo other)
            {
                return string.Equals(EncounterId, other.EncounterId) && string.Equals(PokemonName, other.PokemonName);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((PokemonLocationInfo)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (EncounterId.GetHashCode() * 397) ^ PokemonName.GetHashCode();
                }
            }
        }
    }

