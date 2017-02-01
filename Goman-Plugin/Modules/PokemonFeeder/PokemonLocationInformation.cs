using GoPlugin.Events;
using Newtonsoft.Json;

namespace Goman_Plugin.Modules.PokemonFeeder
{
    public class PokemonLocationInformation
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

        public PokemonLocationInformation(PokemonCaughtEventArgs e, double iv)
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
