using DefaultNamespace;
using Library.Combate;
using Library.Tipos;
using Ucu.Poo.Pokemon;
namespace Ucu.Poo.Pokemon
//En esta clase creamos los personajes, realizamos las acciones e imprimimos el estado de los personajes para obvservar si las
//demas clases funcionan efectivamente.
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu Juego_1 = new Menu();
            Juego_1.AgregarPokemones1("Pikachu");
            Juego_1.AgregarPokemones2("Charmander");
            Juego_1.AgregarPokemones1("Snorlax");
            Juego_1.AgregarPokemones1("Pidgey");
            Juego_1.AgregarPokemones2("Squirtle");
            Juego_1.AgregarPokemones1("Bulbasaur");
            Juego_1.IniciarEnfrentamiento();
            Juego_1.MostrarEstadoRival();
            Juego_1.MostrarAtaquesDisponibles();
            Juego_1.UsarMovimientos(1);
            Juego_1.UsarMovimientos(2);
            Juego_1.MostrarAtaquesDisponibles();
            Juego_1.UsarMovimientos(1);
            Juego_1.UsarMovimientos(2);
            Juego_1.UsarMovimientos(3);
            Juego_1.UsarMovimientos(3);
            Juego_1.MostrarEstadoRival();
            Juego_1.UsarMovimientos(2);
            Juego_1.MostrarEstadoRival();
            Juego_1.UsarMovimientos(1);
            Juego_1.MostrarEstadoRival();
            Juego_1.UsarMovimientos(3);
            Juego_1.UsarMovimientos(1);
            
        }
        
    }
}