using Microsoft.Extensions.Logging;
using MySongs.DTO;
using MySongs.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Flurl;
using Flurl.Http;

namespace MySongs.BLL.Services;


public class PokemonService : IPokemonService
{
    private readonly ILogger<SongService> logger;
    private readonly IConfiguration configuration;

    public PokemonService(ILogger<SongService> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;
    }

    private int GetIdFromUrl(string url)
    {
        try
        {
            //Quick & Dirty way to parse the ID
            var fragments = url.Split('/');
            var ss = fragments[fragments.Length - 1];
            return int.Parse(ss);
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public async Task<List<PokemonDTO>> GetPokemons()
    {
        var baseUrl = configuration.GetSection("AppSettings.PokemonApi").Value ?? String.Empty;
        var url = baseUrl.AppendPathSegment("/api/v2/pokemon/&limit=100");
        var result = await url.GetAsync().ReceiveJson<List<PokemonDTO>>();

        //Extract Id
        result.ForEach(r => r.Id = GetIdFromUrl(r.Url));

        return result;
    }

    public async Task<PokemonDetailDTO> GetPokemon(int id)
    {
        var baseUrl = configuration.GetSection("AppSettings.PokemonApi").Value ?? String.Empty;
        var url = baseUrl.AppendPathSegment($"/api/v2/pokemon/{id}");
        var result = await url.GetAsync().ReceiveJson<PokemonDetailDTO>();
        return result;
    }
}
