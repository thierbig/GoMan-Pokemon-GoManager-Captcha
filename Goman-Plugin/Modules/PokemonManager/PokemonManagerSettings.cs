using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using POGOProtos.Enums;

namespace Goman_Plugin.Modules.PokemonManager
{
    public class PokemonManagerSettings
    {
        public int IntervalMilliseconds { get; set; } = 5000;
        public Dictionary<PokemonId, PokemonManager> Pokemons { get; } = new Dictionary<PokemonId, PokemonManager>();

        [JsonConstructor]
        public PokemonManagerSettings()
        {
        }

        public PokemonManagerSettings(bool newp)
        {
            foreach (PokemonId value in Enum.GetValues(typeof(PokemonId)))
            {
                Pokemons.Add(value, new PokemonManager(value));
            }
        }
    }

    public class PokemonManager
    {
        public PokemonManager(PokemonId pokemonId)
        {
            PokemonId = pokemonId;
        }

        public PokemonId PokemonId { get; set; }
        public int Quantity { get; set; } = 5;
        public int MinimumIv { get; set; } = 0;
        public int MinimumCp { get; set; } = 0;
        public bool AutoFavorite { get; set; } = false;
        public bool AutoUpgrade { get; set; } = false;
        public bool AutoEvolve { get; set; } = false;
    }
}
