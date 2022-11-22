using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySongs.BLL.Interfaces;
using MySongs.BLL.Services;
using MySongsWebApp.Common;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers;

public class PokemonController : Controller
{
    private readonly ILogger<PokemonController> logger;
    private readonly IPokemonService pokemonService;

    public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService)
    {
        this.logger = logger;
        this.pokemonService = pokemonService;
    }

    public IActionResult Index()
    {
        var pokemons = pokemonService.GetPokemons();
        return View(pokemons);
    }

    public IActionResult Detail(int id)
    {
        var pokemon = pokemonService.GetPokemon(id);
        return View(pokemon);
    }
}
