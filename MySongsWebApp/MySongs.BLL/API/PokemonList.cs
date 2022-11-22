using MySongs.DTO;
using System.Text.Json.Serialization;

namespace MySongs.BLL
{
    internal class PokemonList
    {
        [JsonPropertyName("results")]
        public List<PokemonDTO> Results { get; set; }
    }
}
