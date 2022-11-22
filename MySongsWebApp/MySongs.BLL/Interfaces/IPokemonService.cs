using MySongs.DTO;

namespace MySongs.BLL.Interfaces;

public interface IPokemonService
{
    Task<List<PokemonDTO>> GetPokemons();
    Task<PokemonDetailDTO> GetPokemon(int id);
}
