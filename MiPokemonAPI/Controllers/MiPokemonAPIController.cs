

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly PokemonService _pokemonService;

    public PokemonController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet("{Nombre_Del_Pokemon}")]
    public async Task<ActionResult<Pokemon>> Get(string Nombre_Del_Pokemon)
    {
        var pokemon = await _pokemonService.GetFavoritePokemon(Nombre_Del_Pokemon);
        return Ok(pokemon);
    }
}
