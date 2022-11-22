using Microsoft.AspNetCore.Mvc;
using MySongs.BLL.Interfaces;

namespace MySongsWebApp.Controllers;

public class PokemonsController : Controller
{
    private readonly ILogger<PokemonsController> logger;
    private readonly IPokemonService pokemonService;

    public PokemonsController(ILogger<PokemonsController> logger, IPokemonService pokemonService)
    {
        this.logger = logger;
        this.pokemonService = pokemonService;
    }

    public async Task<IActionResult> Index()
    {
        var pokemons = await pokemonService.GetPokemons();
        return View(pokemons);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var pokemon = await  pokemonService.GetPokemon(id);
        return View(pokemon);
    }
}
