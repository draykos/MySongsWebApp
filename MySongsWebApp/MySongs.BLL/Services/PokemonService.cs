using Microsoft.Extensions.Logging;
using MySongs.DTO;
using MySongs.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Flurl.Http;

namespace MySongs.BLL.Services;




public class PokemonService : IPokemonService
{
    private readonly ILogger<SongService> logger;
    private readonly IConfiguration configuration;
    private string baseUrl;


    public PokemonService(ILogger<SongService> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;
        this.baseUrl = configuration.GetSection("AppSettings:PokemonApi").Value ?? String.Empty;

    }

    private int GetIdFromUrl(string url)
    {
        try
        {
            //Quick & Dirty way to parse the ID
            var fragments = url.Split('/');
            var ss = fragments[fragments.Length - 2];
            return int.Parse(ss);
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public async Task<List<PokemonDTO>> GetPokemons()
    {
        var url = $"{baseUrl}/api/v2/pokemon/?limit=100";
        var data = await url.GetAsync().ReceiveJson<PokemonList>();
        var results = data.Results;

        //Extract Id
        results.ForEach(r => r.Id = GetIdFromUrl(r.Url));

        return results;
    }

    public async Task<PokemonDetailDTO> GetPokemon(int id)
    {
        var url = $"{baseUrl}/api/v2/pokemon/{id}";
        var result = await url.GetAsync().ReceiveJson<PokemonDetailDTO>();
        return result;
    }
}
