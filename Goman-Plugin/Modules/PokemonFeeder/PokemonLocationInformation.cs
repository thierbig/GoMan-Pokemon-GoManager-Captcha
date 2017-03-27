using System;
using System.Globalization;
using GoPlugin.Events;
using Newtonsoft.Json;

namespace Goman_Plugin.Modules.PokemonFeeder
{
    public class PokemonLocationInformation
    {
        [JsonProperty("encounter_id")]
        public string EncounterId { get; set; }
        [JsonProperty("spawnpoint_id")]
        public string SpawnPointId { get; set; }
        [JsonProperty("cp")]
        public int? Cp { get; set; }
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }
        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
        [JsonProperty("individual_attack")]
        public int? Attack { get; set; }
        [JsonProperty("individual_defense")]
        public int? Defense { get; set; }
        [JsonProperty("individual_stamina")]
        public int? Stamina { get; set; }
        [JsonProperty("pokemon_id")]
        public int? PokemonName { get; set; }
        [JsonProperty("move_1")]
        public int? Move1 { get; set; }
        [JsonProperty("move_2")]
        public int? Move2 { get; set; }
        [JsonProperty("disappear_time")]
        public string DisappearTime { get; set; }
        [JsonProperty("last_modified")]
        public string LastModified { get; set; }
        [JsonProperty("iv")]
        public double? Iv { get; set; }
        [JsonConstructor]
        public PokemonLocationInformation()
        {
        }
        public PokemonLocationInformation(PokemonEncounteredEventArgs e, double iv)
        {
            EncounterId = Base64Encode(e.WildPokemon.EncounterId.ToString());
            SpawnPointId = e.WildPokemon.SpawnPointId;
            Iv = iv;
            Cp = e.WildPokemon.PokemonData.Cp;
            Latitude = e.WildPokemon.Latitude;
            Longitude = e.WildPokemon.Longitude;
            PokemonName = (int)e.WildPokemon.PokemonData.PokemonId;
            Move1 = (int)e.WildPokemon.PokemonData.Move1;
            Move2 = (int)e.WildPokemon.PokemonData.Move2;
            LastModified = UnixTimeStampToDateTime(e.WildPokemon.LastModifiedTimestampMs / 1000).ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture);

            DisappearTime = 
                e.WildPokemon.TimeTillHiddenMs > 0 
                ?
                DateTime.UtcNow.AddMilliseconds(e.WildPokemon.TimeTillHiddenMs).ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture) 
                :
                DateTime.UtcNow.AddMinutes(30).ToString("yyyy-M-d HH:mm:ss", CultureInfo.InvariantCulture);

            Attack = e.WildPokemon.PokemonData.IndividualAttack;
            Defense = e.WildPokemon.PokemonData.IndividualDefense;
            Stamina = e.WildPokemon.PokemonData.IndividualStamina;
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            return dtDateTime;
        }

        private bool Equals(PokemonLocationInformation other)
        {
            return string.Equals(EncounterId, other.EncounterId) && string.Equals(PokemonName, other.PokemonName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PokemonLocationInformation)obj);
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
