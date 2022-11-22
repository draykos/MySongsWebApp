using System.Text.Json.Serialization;


namespace MySongs.DTO;

public class PokemonDetailDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("base_experience")]
    public string BaseExperience{ get; set; } = "";
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
}
