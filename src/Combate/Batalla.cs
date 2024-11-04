using System.ComponentModel.Design;
using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate
{
    // El principio SRP se aplica ya que esta clase tiene la responsabilidad de manejar la batalla:
    // iniciar, terminar y avanzar el turno de manera clara y precisa.
    public class Batalla
    {
        private bool turnos { get; set; }
        private Jugador jugadorAtacante { get; set; }
        private Jugador jugadorDefensor { get; set; }
        private bool batallaTerminada { get; set; }
        public bool batallaIniciada { get; set; }

        public Batalla()
        {
            this.jugadorAtacante = new Jugador("Ash");
            this.jugadorDefensor = new Jugador("Red");
            this.turnos = true;
            this.batallaTerminada = false;
            this.batallaIniciada = false;
        }

        public void RecibirAtaqueB(IMovimiento_Ataque ataque)
        {
            jugadorDefensor.PokemonAtacado(ataque);
        }

        public Jugador GetAtacante()
        {
            return jugadorAtacante;
        }

        public void AgregarPokemonBA(string pokemon)
        {
            jugadorAtacante.AgregarAlEquipo(pokemon);
        }
        
        public void AgregarPokemonBD(string pokemon)
        {
            jugadorDefensor.AgregarAlEquipo(pokemon);
        }

        public Pokemon GetPokemonActualB()
        {
            return jugadorAtacante.GetPokemonEnTurno();
        }
        

        public double GetHpDefensorB()
        {
            return jugadorDefensor.HpPokemonEnTurno();
        }

        public double GetHpAtacanteB()
        {
            return jugadorAtacante.HpPokemonEnTurno();
        }

        public Jugador GetDefensor()
        {
            return jugadorDefensor;
        }

        public bool GetBatallaTerminada()
        {
            return batallaTerminada;
        }

        public void IniciarBatalla()
        {
            // Verifica si ambos jugadores tienen equipos y la batalla no ha comenzado
            if (!batallaIniciada && jugadorAtacante.GetPokemons().Count > 0 && jugadorDefensor.GetPokemons().Count > 0)
            {
                batallaIniciada = true;
                Console.WriteLine($"La batalla ha iniciado, comienza el jugador {jugadorAtacante.GetName()}");
            }
            else
            {
                Console.WriteLine($"La batalla ya ha comenzado o uno de los jugadores no tiene Pokémon.");
            }
        }

        public void TerminarBatalla()
        {
            // Revisa si alguno de los equipos ha perdido, si ya ha perdido cambia el bool
            if (!jugadorAtacante.TeamIsAlive())
            {
                Console.WriteLine($"¡Ha ganado el jugador {jugadorDefensor.GetName()}!");
                this.batallaTerminada = true;
            }
            else if (!jugadorDefensor.TeamIsAlive())
            {
                Console.WriteLine($"¡Ha ganado el jugador {jugadorAtacante.GetName()}!");
                this.batallaTerminada = true;
            }
        }

        public void AvanzarTurno()
        {
            if (batallaTerminada)
            {
                Console.WriteLine("La batalla ya ha terminado.");
                return; //Corta lo que iba a hacer el metodo y no retorna nada (void)
            }

            // Cambia el Pokémon del jugador defensor si el actual está debilitado
            if (!jugadorDefensor.GetPokemonEnTurno().GetIsAlive())
            {
                bool cambiopermitido = false;
                foreach (var pokemon in jugadorDefensor.GetPokemons())
                {
                    if (pokemon.GetIsAlive())
                    {
                        jugadorDefensor.CambiarPokemon(pokemon);
                        cambiopermitido = true;
                        break;
                    }
                }

                if (!cambiopermitido)
                {
                    Console.WriteLine($"A {jugadorDefensor.GetName()} no le quedan más Pokemones en condiciones de combatir");
                    TerminarBatalla();
                    return;
                }
            }
            if (batallaTerminada == false && jugadorDefensor.TeamIsAlive() && jugadorAtacante.TeamIsAlive())
            {
                Jugador temporal = jugadorAtacante;
                jugadorAtacante = jugadorDefensor;
                jugadorDefensor = temporal;
                turnos = !turnos;
            }
            jugadorDefensor.ActualizarEstadoEquipo();
            TerminarBatalla();
        }
    }
}
