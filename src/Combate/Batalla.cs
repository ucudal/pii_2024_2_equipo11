using System.ComponentModel.Design;
using DefaultNamespace;

namespace Library.Combate;
//El prinicpio SRP se aplica ya que esta clase tiene la responsabilidad de dar la batalla,
//sabiendo cuando inicia, cuando termina y cuando avanza el turno

public class Batalla
{
    private bool turnos { get; set; }
    private Jugador jugadoratacante { get; set; }
    private Jugador jugadordefensor { get; set; }
    private bool batallaTerminada { get; set; }
    public bool batallaIniciada { get; set; }


    public Batalla()
    {
        Pokedex primitiva = new Pokedex();
        this.jugadoratacante = new Jugador("Ash", primitiva);
        this.jugadordefensor = new Jugador("Red", primitiva);
        this.turnos = true;
        this.batallaTerminada = false;
        this.batallaIniciada = false;
    }

    public Jugador GetAtacante()
    {
        return jugadoratacante;
    }
    public Jugador GetDefensor()
    {
        return jugadordefensor;
    }

    public bool GetEstadoBatalla()
    {
        return batallaIniciada;
    }

    public bool GetBatallaTerminada()
    {
        return batallaTerminada;
    }

    public void IniciarBatalla()
    {
        //Cuando ambos jugadores tengan su equipo armado, se dara inicio a la batalla
        if (batallaIniciada == false & jugadoratacante.GetPokemons().Count > 0 & jugadordefensor.GetPokemons().Count > 0)
        {
            batallaIniciada = true;
            Console.WriteLine($"La batalla ha iniciado, inicia el jugador {jugadoratacante.GetName()}");
        }
        else
        {
            Console.WriteLine($"La batalla ya ha comenzado");
        }
        
        
    }

    public string TerminarBatalla()
    {
        //Aqui se revisa quien gano
        if (jugadoratacante.TeamIsAlive() == false)
        {
            return $"Ha ganado el jugador {jugadordefensor.GetName()}!";
            this.batallaTerminada = true;
        }
        else if (jugadordefensor.TeamIsAlive()==false)
        {
            return $"Ha ganado el jugador {jugadoratacante.GetName()}!";
            this.batallaTerminada = true;
        }

        return "";
    }

    public string AvanzarTurno()
    {
        if (jugadordefensor.GetPokemonEnTurno().GetIsAlive() == false)
        {
            foreach (var pokemon in jugadordefensor.GetPokemons())
            {
                if (pokemon.GetIsAlive())
                {
                    jugadordefensor.CambiarPokemon(pokemon);
                    return "Ya ha terminado la batalla!";
                    break;
                }
            }
        }
        //En este metodo lo que se hace es camiar el turno constantemente entre el jugador 1 y 2 haciendo un "toggle"
        if (this.batallaTerminada == false && jugadordefensor.TeamIsAlive() && jugadoratacante.TeamIsAlive())
        {
            Jugador jugador_atacante_aux = jugadoratacante;
            this.jugadoratacante = jugadordefensor;
            jugadordefensor = jugador_atacante_aux;
            this.turnos = !turnos;
        }
        else
        {
            return "Ya ha terminado la batalla!"; 
        }
        jugadordefensor.ActualizarEstadoEquipo();
        TerminarBatalla();

        return "";
    }
}