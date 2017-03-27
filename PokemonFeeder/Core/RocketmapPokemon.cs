using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonFeeder.Core
{
    public class RocketmapResponse
    {
        [JsonProperty("pokemons")]
        public HashSet<PokemonLocationInformation> Pokemons { get; set; }
    }
}
