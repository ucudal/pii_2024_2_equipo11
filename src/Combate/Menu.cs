﻿using DefaultNamespace;
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

        public void UnirJugadores(string jugador)
        {
            batallaActual.AgregarJugador(new Jugador(jugador));
        }

        public double GetHpDefensor()
        {
            return batallaActual.GetHpDefensorB(); 
        }
        public double GetHpAtacante()
        {
            return batallaActual.GetHpAtacanteB(); 
        }
        public Pokemon GetPokemonActual()
        {
            return batallaActual.GetPokemonActualB();
        }

        public void AgregarPokemonesA(string pokemon)
        {
            batallaActual.AgregarPokemonBA(pokemon); 
        }

        public void AgregarPokemonesD(string pokemon)
        {
            batallaActual.AgregarPokemonBD(pokemon);
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
                if (movimiento is IMovimientoEspecial especial && especial.GetUsadoAnteriormente())
                {
                    Console.WriteLine($"{movimiento.GetName()}(especial) no puede ser usado en este turno");
                }
                else
                {
                    if (movimiento is IMovimientoEspecial movimientoEspecial)
                    {
                        Console.WriteLine(movimientoEspecial.GetName(), "(especial)");
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

                    if (movimiento is IMovimientoEspecial especial && especial.GetUsadoAnteriormente())
                    {
                        Console.WriteLine($"El movimiento {movimiento.GetName()} es especial y ya fue usado anteriormente. Elija otro movimiento.");
                    }
                    else
                    {
                        pokemonActual.UsarMovimiento(movimiento);
                        Console.WriteLine($"{pokemonActual.GetName()} ha usado {movimiento.GetName()}.");
                        if (movimiento is IMovimientoAtaque movimientoAtaque)
                        {
                            Random random = new Random();
                            int numeroAleatorio = random.Next(1, 101); //Numero aleatorio para saber si acierto 
                            if (numeroAleatorio <= movimientoAtaque.GetPrecision())
                            {
                                batallaActual.RecibirAtaqueB(movimientoAtaque);
                            }
                            else
                            {
                                Console.WriteLine($"El ataque {movimientoAtaque.GetName()} ha fallado");
                            }
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
