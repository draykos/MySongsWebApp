using System.Text.Json.Serialization;

namespace MySongs.DTO;

public class PokemonDTO
{
    public int Id{ get; set; } = 0;

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("url")]
    public string Url{ get; set; } = "";
}
