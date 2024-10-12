using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate;

public class Menu
{
    private Batalla batallaActual;

    public Menu()
    {
        batallaActual = new Batalla();
    }

    public void AgregarPokemones1(string nombrepokemon)
    {
        batallaActual.GetAtacante().AgregarAlEquipo(nombrepokemon);
    }
    public void AgregarPokemones2(string nombrepokemon)
    {
        batallaActual.GetDefensor().AgregarAlEquipo(nombrepokemon);
    }
    
    public void IniciarEnfrentamiento()
    {
        batallaActual.IniciarBatalla();
    }
    public void MostrarEstadoRival()
    {
        Jugador atacante= batallaActual.GetAtacante();
        atacante.MostarEstadoEquipo();
    }

    public void MostrarEstadoEquipo()
    {
        Jugador defensor= batallaActual.GetDefensor();
        defensor.MostarEstadoEquipo();
    }

    public void CambiarPokemon(int numerodepokemon)
    {

        Jugador jugadorAtacante = batallaActual.GetAtacante();
        List<Pokemon> pokemons = jugadorAtacante.GetPokemons();
        Pokemon pokemonelegido = pokemons[numerodepokemon];
        if (pokemonelegido.GetIsAlive())
        {
            jugadorAtacante.CambiarPokemon(pokemonelegido);
            
            Console.WriteLine($"El pokemon {pokemonelegido.GetName()} ha entrado en combate");
            batallaActual.AvanzarTurno();//Al cambiar de pokemon el jugador pierde el turno
        }
        else
        {
            Console.WriteLine($"El pokemon {pokemonelegido.GetName()} está debilitado no puede entrar en combate");
        }
    }

    public void MostrarAtaquesDisponibles()
    {
        Jugador jugadorAtacante = batallaActual.GetAtacante();
        Pokemon pokemon = jugadorAtacante.GetPokemonEnTurno();
        Console.WriteLine($"El Pokemon {pokemon.GetName()} tiene los movimientos:");
        foreach (IMovimiento movimiento in pokemon.GetListaMovimientos())
        {
            if (movimiento.GetesEspecial() && movimiento.GetUsado_Anteriormente())
            {
                Console.WriteLine($"{movimiento.GetName()}(especial) no puede ser usado en este turno");
            }
            else
            {
                if (movimiento.GetesEspecial())
                {
                    Console.WriteLine(movimiento.GetName(), "(especial)");
                }
                else
                {
                    Console.WriteLine(movimiento.GetName());
                }
            }
        }
    }

    public void UsarMovimientos(int numdemovimiento)
    {
        if (batallaActual.GetBatallaTerminada())
        {
            Console.WriteLine("La batalla ya ha terminado");
        }
        else if (numdemovimiento > 0 && numdemovimiento <= 4)
        {
            Jugador jugador = batallaActual.GetAtacante();
            Pokemon pokemonActual = jugador.GetPokemonEnTurno();
            IMovimiento movimiento = pokemonActual.GetListaMovimientos()[numdemovimiento - 1];
            if (movimiento.GetesEspecial() & movimiento.GetUsado_Anteriormente())
            {
                Console.WriteLine($"El movimiento {movimiento.GetName()} es especial y ya fue usado anteriormente, elija otro movimiento");
            }
            else
            {
                pokemonActual.UsarMovimiento(movimiento);
                if (movimiento is IMovimiento_Ataque movimiento1)
                {
                    batallaActual.GetDefensor().GetPokemonEnTurno().RecibirAtaque(movimiento1);
                }
                Console.WriteLine($"{batallaActual.GetAtacante().GetPokemonEnTurno().GetName()} ha usado {movimiento.GetName()}");
                batallaActual.AvanzarTurno();
            }
        }
        else
        {
            Console.WriteLine("Ha escogido un movimiento que no existe, por favor digite un movimiento entre 1 y 4 o uno que se pueda escojer en otro turno");
        }
    }

    public void MostrarNumPokemon()
    {
        Jugador jugador = batallaActual.GetAtacante();
        List<Pokemon> Lista_pokemons = jugador.GetPokemons();
        foreach (Pokemon pokemon in Lista_pokemons)
        {
            int numPokemon = Lista_pokemons.IndexOf(pokemon);
            Console.WriteLine($"{numPokemon}. {pokemon.GetName()}");
        }
    }
}