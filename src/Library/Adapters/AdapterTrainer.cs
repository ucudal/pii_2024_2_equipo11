using DefaultNamespace;
using Library.Combate;
using Library.Tipos;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.Pokemon;
//Clase de AdapterTrainer cumple con SRP ya que tiene la única responsabilidad de actuar como "puente" entre Jugador y
//Trainer de bot para que éste se adapte a la interfaz que utilizamos.
//Cumple con Expert ya que es la que tiene toda esa información para actuar de esa manera
//Cumple con OCP ya que está abierto a extensiones pero cerrado a modificaciones,
//ya que por ejemplo puedes adaptar nuevas funcionalidades de Jugador que añadas sin que esto afecte a lo que ya está hecho
//También cumple con LSP ya que puede usarse donde se espere un objeto de tipo Trainer sin romper nada.
namespace AdapterNamespace;

/// <summary>
/// Adaptador para conectar la clase `Jugador` con la clase `Trainer` del bot.
/// </summary>
public class AdapterTrainer: Trainer
{
    private readonly Jugador _jugador;
    
    /// <summary>
    /// Crea una instancia del adaptador para usar `Jugador` como `Trainer`.
    /// </summary>
    /// <param name="name">El nombre del entrenador.</param>
    public AdapterTrainer(string name) : base(name)
    {
        Jugador _jugador = new Jugador(name);
    }

    /// <summary>
    /// Verifica si el Pokémon en turno puede atacar.
    /// </summary>
    /// <returns>True si el Pokémon puede atacar, False en caso contrario.</returns>
    public bool GetpokemonEnTurnoAtaca()
    {
        return _jugador.GetPokemonEnTurnoAtaca();
    }

    /// <summary>
    /// Aplica el efecto de un Pokémon en turno sobre otro Pokémon.
    /// </summary>
    /// <param name="pokemon">El Pokémon objetivo.</param>
    /// <returns>Un mensaje indicando el resultado del efecto.</returns>

    public string HacerEfectoPokemonEnTurno(Pokemon pokemon)
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.HacerEfectoPokemon(pokemon);
    }

    /// <summary>
    /// Obtiene el efecto actual del Pokémon en turno.
    /// </summary>
    /// <returns>El efecto aplicado por el Pokémon en turno.</returns>

    public Efecto GetEfectoPokemonTurno()
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.GetEfecto();
    }

    /// <summary>
    /// Aplica un ataque al Pokémon en turno.
    /// </summary>
    /// <param name="ataque">El ataque a aplicar.</param>
    /// <returns>Un mensaje indicando el resultado del ataque.</returns>

    public string PokemonAtacado(IMovimientoAtaque ataque)
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.RecibirAtaque(ataque);
    }

    /// <summary>
    /// Obtiene la cantidad de Pokémon en el equipo del entrenador.
    /// </summary>
    /// <returns>La cantidad de Pokémon en el equipo.</returns>

    public int GetCantpokemon()
    {
        List<Pokemon> listapokemones = _jugador.GetPokemons();
        return listapokemones.Count;
    }

    /// <summary>
    /// Verifica si el Pokémon en turno sigue con vida.
    /// </summary>
    /// <returns>True si está vivo, False en caso contrario.</returns>

    public bool PokemonEnTurnoAlive()
    {
        Pokemon pokemonEnTurno = GetPokemonEnTurno();
        return pokemonEnTurno.GetIsAlive();
    }

    /// <summary>
    /// Obtiene el nombre del entrenador.
    /// </summary>
    /// <returns>El nombre del entrenador.</returns>

    public string GetName()
    {
        return _jugador.GetName();
    }

    /// <summary>
    /// Verifica si el equipo del entrenador sigue con vida.
    /// </summary>
    /// <returns>True si el equipo está vivo, False en caso contrario.</returns>

    public bool TeamIsalive()
    {
        return _jugador.TeamIsAlive();
    }

    /// <summary>
    /// Agrega un nuevo Pokémon al equipo del entrenador.
    /// </summary>
    /// <param name="name">El nombre del Pokémon a agregar.</param>
    /// <returns>Un mensaje indicando el resultado de la operación.</returns>

    public string AgregarAlEquipo(string name)
    {
        return _jugador.AgregarAlEquipo(name);
    }

    /// <summary>
    /// Actualiza el estado del equipo del entrenador.
    /// </summary>

    public void ActualizarEstadoEquipo()
    {
        _jugador.ActualizarEstadoEquipo();
    }

    /// <summary>
    /// Cambia el Pokémon en turno por otro Pokémon del equipo.
    /// </summary>
    /// <param name="pokemon">El nuevo Pokémon en turno.</param>

    public void CambiarPokemon(Pokemon pokemon)
    {
        _jugador.CambiarPokemon(pokemon);
    }

    /// <summary>
    /// Obtiene el Pokémon actualmente en turno.
    /// </summary>
    /// <returns>El Pokémon en turno.</returns>

    public Pokemon GetPokemonEnTurno()
    {
        return _jugador.GetPokemonEnTurno();
    }

    /// <summary>
    /// Obtiene los puntos de salud del Pokémon en turno.
    /// </summary>
    /// <returns>Los puntos de salud del Pokémon en turno.</returns>

    public double HpPokemonEnTurno()
    {
        return _jugador.HpPokemonEnTurno();
    }

    /// <summary>
    /// Muestra el estado actual del equipo del entrenador.
    /// </summary>
    /// <returns>Un mensaje con el estado del equipo.</returns>

    public string MostarEstadoEquipo()
    {
        return _jugador.MostarEstadoEquipo();
    }

    /// <summary>
    /// Usa un ítem sobre un Pokémon del equipo.
    /// </summary>
    /// <param name="item">El nombre del ítem a usar.</param>
    /// <param name="pokemon">El Pokémon sobre el que se usará el ítem.</param>
    /// <returns>Un mensaje indicando el resultado del uso del ítem.</returns>

    public string UseItem(string item, Pokemon pokemon)
    {
        return _jugador.UsarItem(item, pokemon);
    }

    /// <summary>
    /// Muestra los ítems disponibles del entrenador.
    /// </summary>
    /// <returns>Un mensaje con la lista de ítems disponibles.</returns>
    public string MostrarItems()
    {
        return _jugador.MostrarItems();
    }
}