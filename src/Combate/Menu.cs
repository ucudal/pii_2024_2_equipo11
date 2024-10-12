using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate
{
    public class Menu
    {
        private Batalla batallaActual;

        public Menu()
        {
            batallaActual = new Batalla();
        }

        public int GetHpDefensor()
        {
            return batallaActual.GetDefensor().GetPokemonEnTurno().GetVidaActual();
        }
        public int GetHpAtacante()
        {
            return batallaActual.GetAtacante().GetPokemonEnTurno().GetVidaActual();
        }
        

        public void AgregarPokemones1(string nombrePokemon)
        {
            batallaActual.GetAtacante().AgregarAlEquipo(nombrePokemon);
        }

        public void AgregarPokemones2(string nombrePokemon)
        {
            batallaActual.GetDefensor().AgregarAlEquipo(nombrePokemon);
        }

        public void IniciarEnfrentamiento()
        {
            batallaActual.IniciarBatalla();
        }

        public void MostrarEstadoRival()
        {
            // Muestra el estado del defensor, no del atacante
            Jugador defensor = batallaActual.GetDefensor();
            defensor.MostarEstadoEquipo();
        }

        public void MostrarEstadoEquipo()
        {
            // Muestra el estado del atacante
            Jugador atacante = batallaActual.GetAtacante();
            atacante.MostarEstadoEquipo();
        }

        public void CambiarPokemon(int numeroDePokemon)
        {
            Jugador jugadorAtacante = batallaActual.GetAtacante();
            List<Pokemon> pokemons = jugadorAtacante.GetPokemons();
            
            if (numeroDePokemon >= 0 && numeroDePokemon < pokemons.Count)
            {
                Pokemon pokemonElegido = pokemons[numeroDePokemon];
                
                if (pokemonElegido.GetIsAlive())
                {
                    jugadorAtacante.CambiarPokemon(pokemonElegido);
                    Console.WriteLine($"El Pokémon {pokemonElegido.GetName()} ha entrado en combate");
                    batallaActual.AvanzarTurno();
                }
                else
                {
                    Console.WriteLine($"El Pokémon {pokemonElegido.GetName()} está debilitado y no puede entrar en combate");
                }
            }
            else
            {
                Console.WriteLine("No tienes ese pokemon");
            }
        }

        public void MostrarAtaquesDisponibles()
        {
            Jugador jugadorAtacante = batallaActual.GetAtacante();
            Pokemon pokemon = jugadorAtacante.GetPokemonEnTurno();
            Console.WriteLine($"El Pokémon {pokemon.GetName()} tiene los siguientes movimientos:");
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
        

        public void UsarMovimientos(int numDeMovimiento)
        {
            if (batallaActual.GetBatallaTerminada())
            {
                Console.WriteLine("La batalla ya ha terminado.");
                return;
            }
                Jugador jugador = batallaActual.GetAtacante();
                Pokemon pokemonActual = jugador.GetPokemonEnTurno();
                List<IMovimiento> movimientos = pokemonActual.GetListaMovimientos();
                if (numDeMovimiento > 0 && numDeMovimiento <= movimientos.Count)
                {
                    IMovimiento movimiento = movimientos[numDeMovimiento - 1]; //acomodo por la lista

                    if (movimiento.GetesEspecial() && movimiento.GetUsado_Anteriormente())
                    {
                        Console.WriteLine($"El movimiento {movimiento.GetName()} es especial y ya fue usado anteriormente. Elija otro movimiento.");
                    }
                    else
                    {
                        pokemonActual.UsarMovimiento(movimiento);
                        Console.WriteLine($"{pokemonActual.GetName()} ha usado {movimiento.GetName()}.");
                        if (movimiento is IMovimiento_Ataque movimientoAtaque)
                        {
                            
                            batallaActual.GetDefensor().GetPokemonEnTurno().RecibirAtaque(movimientoAtaque);
                        }
                        batallaActual.AvanzarTurno();
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento inválido. Por favor, seleccione un movimiento entre 1 y 4, o uno que pueda usarse en este turno.");
                }
            }
        public void MostrarNumPokemon()
        {
            Jugador jugador = batallaActual.GetAtacante();
            List<Pokemon> listaPokemons = jugador.GetPokemons();
            for (int i = 0; i < listaPokemons.Count; i++)
            {
                Pokemon pokemon = listaPokemons[i];
                Console.WriteLine($"{i}. {pokemon.GetName()}");
            }
        }
    }
}
