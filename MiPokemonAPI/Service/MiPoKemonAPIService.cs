
using System.Net.Http.Json;
using System.Text.Json;
using MiPokemonAPI.Models;
namespace System.Net.Http.Header;


public class PokemonService
{
    private readonly HttpClient _cliente;

    public PokemonService(HttpClient client)
    {
        _cliente = client; 
    }

    public async Task<Pokemon> GetFavoritePokemon(string pokeName)
    {
        var response = await _cliente.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokeName}");
        response.EnsureSuccessStatusCode();

        var pokemonData = await response.Content.ReadFromJsonAsync<JsonElement>();

        var pokemon = new Pokemon
        {
            Nombre = pokeName,
            Tipo = pokemonData.GetProperty("types")[0].GetProperty("type").GetProperty("name").GetString(),
            URL = pokemonData.GetProperty("sprites").GetProperty("front_default").GetString(),
            Movimientos = (from move in pokemonData.GetProperty("moves").EnumerateArray()
           select move.GetProperty("move").GetProperty("name").GetString()).ToList()
        };


        return pokemon;
    }
    
}
