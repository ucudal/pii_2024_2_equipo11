namespace DefaultNamespace;

public class Jugador
{
    private string name { get; set; }
    private List<IPokemon> lista_pokemons {get;set;}
    private IPokemon pokemonEnTurno {get;set;}
    private int turnosjugados {get;set;}
    private bool esMiTurno {get;set;}
    private bool teamIsAlive {get;set;}

    private Jugador(string name)
    {
        this.name = name;
        this.lista_pokemons = new List<IPokemon>;
        this.turnosjugados = 0;
        this.esMiTurno = false;
        this.teamIsAlive = true;
    }
    
    publc void CambiarPokemonEnTurno(IPokemon pokemon)
    {
        //Este metodo permite cambiar el pokemon que el jugador esta utilizando actualmente por otro dentro de los de su propio equipo (siempre y cuando el otro pokemon se encuentre con vida)
        //al hacer este cambio el jugador pierde su turno.
    }

    public void MostrarAtaquesDisponibles()
    {
        //Este metodo nos permitira mostrarle al usuario todos los Pokemos de su equipo con vida y sus ataques disponibles (teniendo en cuenta que los especiales aparecen cada 2 turnos)
    }
}